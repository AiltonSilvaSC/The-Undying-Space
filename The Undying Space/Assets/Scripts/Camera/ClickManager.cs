using Assets.Scripts.Enuns;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickManager : MonoBehaviour
{
    private Camera _camera;
    private Objeto _objetoAnterior;

    private void Start() => _camera = GetComponent<Camera>();

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            // Verifica se clicou em uma nave.
            int mask = LayerMask.GetMask("Naves");
            var hit = Physics2D.Raycast(mousePos2D, Vector2.zero, 10, mask);
            if (hit.collider != null)
            {
                if (_objetoAnterior != null)
                    _objetoAnterior.DesativarSelection();

                if (hit.collider.TryGetComponent<Objeto>(out var objeto))
                {
                    Debug.Log(objeto.TipoObjeto);
                    switch (objeto.TipoObjeto)
                    {
                        case EnumObjetos.SpaceShip:
                            if (hit.collider.TryGetComponent<SpaceShip>(out var spaceShip))
                            {
                                UIManager.instance.AtualizarSpaceShipPanel(spaceShip.TipoNave);
                                _objetoAnterior = objeto;
                                objeto.MostrarSelection();
                            }
                            else
                                Debug.LogError("Script SpaceShip não encontrado neste objeto!");
                            break;
                    }
                    return;
                }
                else
                    Debug.LogError("Script Objeto não encontrado neste objeto!");
            }
            else if (true)
            {
                // Verifica se clicou em alguma construção, e depois um planeta.
                mask = LayerMask.GetMask("PlanetaConstrucao");
                hit = Physics2D.Raycast(mousePos2D, Vector2.zero, 10, mask);
                if (hit.collider != null)
                {
                    if (_objetoAnterior != null)
                        _objetoAnterior.DesativarSelection();

                    if (hit.collider.TryGetComponent<Objeto>(out var objeto))
                    {

                        Debug.Log(objeto.TipoObjeto);
                        switch (objeto.TipoObjeto)
                        {
                            case EnumObjetos.Planet:
                                if (hit.collider.TryGetComponent<Planet>(out var planet))
                                {
                                    Debug.Log(planet.Nome);
                                    UIManager.instance.AtualizarPlanetPanel();
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
                        UIManager.instance.DesativarSelectionPanel();
                        if (_objetoAnterior != null)
                        {
                            _objetoAnterior.DesativarSelection();
                            _objetoAnterior = null;
                        }
                    }
                }
            }
        }

    }
}