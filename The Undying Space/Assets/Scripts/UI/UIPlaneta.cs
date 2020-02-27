using Assets.Scripts;
using Assets.Scripts.Enuns;
using UnityEngine;
using UnityEngine.UI;

public class UIPlaneta : MonoBehaviour
{
    [SerializeField]
    private GameObject _uiPlaneta = null;
    [SerializeField]
    private Text _uiPlanetaNome = null;
    [SerializeField]
    private Text _uiPlanetaQualidade = null;
    [SerializeField]
    private Text _uiPlanetaTamanho = null;
    [SerializeField]
    private Text _uiPlanetaTipo = null;
    [SerializeField]
    private Text _uiPlanetaDono = null;

    public void AtivarPanel(string nome, float qualidade, float tamanho, EnumPlanetas tipo, string dono)
    {
        _uiPlaneta.SetActive(true);
        _uiPlanetaNome.text = nome;
        _uiPlanetaQualidade.text = $"{(int)(qualidade * 100)}%";
        _uiPlanetaTamanho.text = tamanho.Text() + " mil";
        _uiPlanetaTipo.text = tipo.GetDescription();
        _uiPlanetaDono.text = dono;
    }

    public void DesativarPanel()
    {
        _uiPlaneta.SetActive(false);
    }
}
