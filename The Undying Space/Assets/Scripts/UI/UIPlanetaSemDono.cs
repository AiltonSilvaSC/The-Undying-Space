using Assets.Scripts;
using Assets.Scripts.Enuns;
using UnityEngine;
using UnityEngine.UI;

public class UIPlanetaSemDono : MonoBehaviour
{
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

    public void AtivarPanel(string nome, float qualidade, float tamanho, EnumPlanetas tipo)
    {
        _planetaSemDono.SetActive(true);
        _planetaSemDonoNome.text = nome;
        _planetaSemDonoQualidade.text = $"{(int)(qualidade * 100)}%";
        _planetaSemDonoTamanho.text = tamanho.Text() + " mil";
        _planetaSemDonoTipo.text = tipo.GetDescription();
    }

    public void DesativarPanel()
    {
        _planetaSemDono.SetActive(false);
    }
}
