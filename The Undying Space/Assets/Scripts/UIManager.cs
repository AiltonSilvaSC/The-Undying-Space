using Assets.Scripts;
using Assets.Scripts.Enuns;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instancia { get; private set; }

    #region UI


    [SerializeField]
    private UIPlaneta _uiPlaneta;
    [SerializeField]
    private UISpaceShip _uiSpaceShip;

    #endregion






    [SerializeField]
    private GameObject _panelCriarNave = null;
    [SerializeField]
    private GameObject _buttonCriarNave = null;

    private void Awake()
    {
        if (Instancia == null)
            Instancia = this;
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
        _uiSpaceShip.DesativarPanel();
        _uiPlaneta.DesativarPanel();
    }

    public void AtualizarPlanetPanel(string nome, float qualidade, float tamanho, EnumPlanetas tipo, string dono = null)
    {
        DesativarSelectionPanel();
        if (dono == null)
            dono = "Nenhum dono";
        _uiPlaneta.AtivarPanel(nome, qualidade, tamanho, tipo, dono);
    }

    public void AtualizarSpaceShipPanel(string nome, EnumEspaconaves tipo, string dono = null)
    {
        DesativarSelectionPanel();
        if (dono == null)
            dono = "Nenhum dono";
        _uiSpaceShip.AtivarPanel(nome, tipo, dono);
    }

    public void MostraButtonCriarNave() => _buttonCriarNave.SetActive(true);
    public void RemoverButtonCriarNave() => _buttonCriarNave.SetActive(false);

    public void MostrarPanelCriarNave()
    {
        _panelCriarNave.SetActive(true);
        GameControl.instance.PausarGame(true);
    }

    public void FecharPanelCriarNave()
    {
        _panelCriarNave.SetActive(false);
        GameControl.instance.PausarGame(false);
    }
}
