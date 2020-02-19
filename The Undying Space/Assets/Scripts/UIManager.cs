using Assets.Scripts;
using Assets.Scripts.Enuns;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    #region SelectionPanel
    #region SpaceShip
    [SerializeField]
    private GameObject _spaceShipPanel;
    [SerializeField]
    private Text _spaceShipTipo;
    #endregion
    #endregion
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);


    }

    void Start()
    {
        gameObject.SetActive(true);
        DesativarSelectionPanel();
    }

    public void DesativarSelectionPanel()
    {
        _spaceShipPanel.SetActive(false);
    }

    public void AtualizarSpaceShipPanel(EnumTipo tipo)
    {
        DesativarSelectionPanel();
        _spaceShipPanel.SetActive(true);
        _spaceShipTipo.text = tipo.GetDescription();
    }

    public void AtualizarPlanetPanel()
    {
        DesativarSelectionPanel();
    }
}
