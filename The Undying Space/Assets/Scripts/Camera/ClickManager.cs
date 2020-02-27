using Assets.Scripts.Enuns;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickManager : MonoBehaviour
{
    private Camera _camera;
    private Objeto _objetoAnterior;
    [HideInInspector]
    public bool funcionar;

    private void Awake() => funcionar = true;

    private void Start() => _camera = GetComponent<Camera>();

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && funcionar == true)
        {
            #region Mouse 
            Vector3 mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            #endregion 
            // Verifica se clicou em uma nave.
            int mask = LayerMask.GetMask("Naves");
            var hit = Physics2D.Raycast(mousePos2D, Vector2.zero, 10, mask);
            if (hit.collider != null)
            {
                DesativarAnterior();

                if (hit.collider.TryGetComponent<Objeto>(out var objeto))
                {
                    if (hit.collider.TryGetComponent<SpaceShip>(out var spaceShip))
                    {
                        _objetoAnterior = objeto;
                        objeto.MostrarSelection();
                        UIManager.instance.AtualizarSpaceShipPanel(spaceShip.Nome, spaceShip.TipoNave, objeto.Dono);
                    }
                    else
                        Debug.LogError("Script SpaceShip não encontrado neste objeto!");
                    return;
                }
            }
            else if (true)
            {
                #region Verificacao Planeta ou Construção
                // Verifica se clicou em alguma construção, e depois um planeta.
                mask = LayerMask.GetMask("PlanetaConstrucao");
                hit = Physics2D.Raycast(mousePos2D, Vector2.zero, 10, mask);
                if (hit.collider != null)
                {
                    DesativarAnterior();

                    if (hit.collider.TryGetComponent<Objeto>(out var objeto))
                    {
                        #endregion
                        switch (objeto.tipoObjeto)
                        {
                            case EnumObjetos.Planeta:
                                if (hit.collider.TryGetComponent<ObjetoPlaneta>(out var planet))
                                {
                                    _objetoAnterior = objeto;
                                    objeto.MostrarSelection();
                                    if (objeto.idJogadorAtual == 1)
                                        UIManager.instance.MostraButtonCriarNave();
                                    UIManager.instance.AtualizarPlanetPanel(planet.nome, planet.qualidade, planet.tamanho, planet.tipo, objeto.Dono);
                                }
                                else
                                    Debug.LogError("Script Planet não encontrado neste objeto!");
                                break;
                        }
                        return;
                    }
                    else
                        Debug.LogError("Script Objeto não encontrado neste objeto!");
                }
                else
                {
                    // Verifica se clicou na UI. Caso não tenha, remove seleção.
                    PointerEventData cursor = new PointerEventData(EventSystem.current);
                    cursor.position = Input.mousePosition;
                    List<RaycastResult> objectsHit = new List<RaycastResult>();
                    EventSystem.current.RaycastAll(cursor, objectsHit);
                    if (objectsHit.Count == 0)
                    {
                        DesativarAnterior();
                    }
                }
            }
        }
    }

    private void DesativarAnterior()
    {
        if (_objetoAnterior != null)
            _objetoAnterior.DesativarSelection();
        UIManager.instance.DesativarSelectionPanel();
        UIManager.instance.RemoverButtonCriarNave();
    }
}
