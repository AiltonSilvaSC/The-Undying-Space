using Assets.Scripts.Enuns;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// Adicionar na camera.
public class ClickManager : MonoBehaviour
{
    private Camera _camera;


    public Objeto objetoSelecionado;
    public ObjetoSpaceShip objetoSelecionadoSpaceShip;
    private LineRenderer _lineRenderer;

    public static ClickManager Instancia { get; private set; }

    public bool Funcionar { get; set; }

    private void Awake()
    {
        if (Instancia == null)
            Instancia = this;
        Funcionar = true;

        _lineRenderer = gameObject.AddComponent<LineRenderer>();
        _lineRenderer.sortingLayerName = "Fundo";
        _lineRenderer.sortingOrder = 3;
        _lineRenderer.startColor = Color.yellow;
        _lineRenderer.widthMultiplier = 0.300f;
        _lineRenderer.material = Resources.Load("Materials/MaterialWhite", typeof(Material)) as Material;
        _lineRenderer.loop = false;
    }
    private void Start() => _camera = GetComponent<Camera>();

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Funcionar == true)
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
                    if (hit.collider.TryGetComponent<ObjetoSpaceShip>(out var spaceShip))
                    {
                        objetoSelecionado = objeto;
                        objeto.MostrarSelection();
                        objetoSelecionadoSpaceShip = spaceShip;
                        UIManager.Instancia.AtualizarSpaceShipPanel(spaceShip.Nome, spaceShip.TipoNave, objeto.Dono);
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
                                    objetoSelecionado = objeto;
                                    objeto.MostrarSelection();
                                    if (objeto.idJogadorAtual == 1)
                                        UIManager.Instancia.MostraButtonCriarNave();
                                    UIManager.Instancia.AtualizarPlanetPanel(planet.nome, planet.qualidade, planet.tamanho, planet.tipo, objeto.Dono);
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

        //Botão direito em algo
        if (Input.GetMouseButtonDown(1) && Funcionar == true)
        {
            if (objetoSelecionadoSpaceShip != null)
            {
                if (objetoSelecionado.DonoIsJogador)
                {
                    Objeto alvo = null;

                    Vector3 mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
                    Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
                    int mask = LayerMask.GetMask("Naves");
                    var hit = Physics2D.Raycast(mousePos2D, Vector2.zero, 10, mask);
                    if (hit.collider != null)
                    {
                        hit.collider.TryGetComponent(out alvo);
                    }
                    else if (true)
                    {
                        // Verifica se clicou em alguma construção, e depois um planeta.
                        mask = LayerMask.GetMask("PlanetaConstrucao");
                        hit = Physics2D.Raycast(mousePos2D, Vector2.zero, 10, mask);
                        if (hit.collider != null)
                        {
                            hit.collider.TryGetComponent(out alvo);
                        }
                        else
                        {
                            // Verifica se clicou na UI. Caso não tenha move a espaconave para a posição desejada.
                            PointerEventData cursor = new PointerEventData(EventSystem.current);
                            cursor.position = Input.mousePosition;
                            List<RaycastResult> objectsHit = new List<RaycastResult>();
                            EventSystem.current.RaycastAll(cursor, objectsHit);
                            if (objectsHit.Count == 0)
                            {
                                objetoSelecionadoSpaceShip.alvo = mousePos2D;
                                objetoSelecionadoSpaceShip.mover = true;
                            }
                        }
                    }


                }
            }
        }
    }

    private void DesativarAnterior()
    {
        if (objetoSelecionado != null)
            objetoSelecionado.DesativarSelection();
        if (objetoSelecionadoSpaceShip != null)
            objetoSelecionadoSpaceShip = null;
        if (_lineRenderer != null)
            _lineRenderer.positionCount = 0;
        UIManager.Instancia.DesativarSelectionPanel();
        UIManager.Instancia.RemoverButtonCriarNave();
    }

    private void FixedUpdate()
    {
        if (_lineRenderer != null && objetoSelecionadoSpaceShip != null)
        {
            if (objetoSelecionadoSpaceShip.mover)
            {
                _lineRenderer.positionCount = 2;
                _lineRenderer.SetPosition(0, objetoSelecionadoSpaceShip.transform.position);
                _lineRenderer.SetPosition(1, objetoSelecionadoSpaceShip.alvo);
            }
        }
    }
}
