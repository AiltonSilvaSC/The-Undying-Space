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
    private GameObject _spaceShipPanel = null;
    [SerializeField]
    private Text _spaceShipTipo = null;
    #endregion


    #region Planeta
    [SerializeField]
    private GameObject _planetaSemDono = null;
    [SerializeField]
    private Text _planetaSemDonoNome = null;
    [SerializeField]
    private Text _planetaSemDonoQualidade = null;
    [SerializeField]
    private Text _planetaSemDonoTamanho = null;
    [SerializeField]
    private Text _planetaSemDonoTipo = null;
    [SerializeField]

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
        _planetaSemDono.SetActive(false);
    }

    public void AtualizarSpaceShipPanel(EnumTipos tipo)
    {
        DesativarSelectionPanel();
        _spaceShipPanel.SetActive(true);
        _spaceShipTipo.text = tipo.GetDescription();
    }

    public void AtualizarPlanetPanel(string nome, float qualidade, float tamanho, EnumPlanetas tipo)
    {
        DesativarSelectionPanel();
        _planetaSemDono.SetActive(true);
        _planetaSemDonoNome.text = nome;
        _planetaSemDonoQualidade.text = $"{(int)(qualidade * 100)}%";
        _planetaSemDonoTamanho.text = tamanho.Text();
        _planetaSemDonoTipo.text = tipo.GetDescription();
    }
}
