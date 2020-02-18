using Assets.Scripts.Enuns;
using UnityEngine;
using UnityEngine.UI;

public class ClickManager : MonoBehaviour
{
    private Camera _camera;
    public GameObject PanelGUI;
    private void Start()
    {
        _camera = GetComponent<Camera>();
        PanelGUI.transform.Find("ObjetoNome").GetComponent<Text>().text = "";
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.TryGetComponent<Objeto>(out var objeto))
                {
                    Debug.Log(objeto.TipoObjeto);
                    switch (objeto.TipoObjeto)
                    {
                        case EnumObjeto.SpaceShip:
                            if (hit.collider.TryGetComponent<SpaceShip>(out var spaceShip))
                            {
                                Debug.Log(spaceShip.Nome);
                                PanelGUI.transform.Find("ObjetoNome").GetComponent<Text>().text = spaceShip.Nome;
                            }
                            else
                                Debug.LogError("Script SpaceShip não encontrado neste objeto!");
                            break;
                        case EnumObjeto.Planet:
                            if (hit.collider.TryGetComponent<Planet>(out var planet))
                            {
                                Debug.Log(planet.Nome);
                                PanelGUI.transform.Find("ObjetoNome").GetComponent<Text>().text = planet.Nome;
                            }
                            else
                                Debug.LogError("Script Planet não encontrado neste objeto!");
                            break;
                    }
                }
                else
                    Debug.LogError("Script Objeto não encontrado neste objeto!");
            }
            else
            {
                PanelGUI.transform.Find("ObjetoNome").GetComponent<Text>().text = "";
            }
        }
    }

}