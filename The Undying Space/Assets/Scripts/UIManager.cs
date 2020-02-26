using Assets.Scripts;
using Assets.Scripts.Enuns;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField]
    private GameControl _gameControl;
    [SerializeField]
    private UIPlanetaSemDono _planetaSemDono;


    [SerializeField]
    private GameObject _spaceShipPanel = null;
    [SerializeField]
    private Text _spaceShipTipo = null;





    [SerializeField]
    private GameObject _panelCriarNave = null;
    [SerializeField]
    private GameObject _buttonCriarNave = null;

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
        _planetaSemDono.DesativarPanel();
    }

    public void AtualizarSpaceShipPanel(EnumEspaconaves tipo)
    {
        DesativarSelectionPanel();
        _spaceShipPanel.SetActive(true);
        _spaceShipTipo.text = tipo.GetDescription();
    }

    public void AtualizarPlanetPanel(string nome, float qualidade, float tamanho, EnumPlanetas tipo)
    {
        DesativarSelectionPanel();
        _planetaSemDono.AtivarPanel(nome, qualidade, tamanho, tipo);
    }

    public void AtivarButtonCriarNave()
    {
        _buttonCriarNave.SetActive(true);
    }

    public void DesativarButtonCriarNave()
    {
        _buttonCriarNave.SetActive(false);
    }

    public void AtivarPanelCriarNave()
    {
        _panelCriarNave.SetActive(true);
        _gameControl.PausarGame(true);
    }

    public void DesativarPanelCriarNave()
    {
        _panelCriarNave.SetActive(false);
        _gameControl.PausarGame(false);
    }
}
