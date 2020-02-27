using Assets.Scripts;
using Assets.Scripts.Enuns;
using UnityEngine;
using UnityEngine.UI;

public class UISpaceShip : MonoBehaviour
{
    [SerializeField]
    private GameObject _uiSpaceShip = null;
    [SerializeField]
    private Text _uiSpaceShipNome = null;
    [SerializeField]
    private Text _uiSpaceShipTipo = null;
    [SerializeField]
    private Text _uiSpaceShipDono = null;

    public void AtivarPanel(string nome, EnumEspaconaves tipo, string dono)
    {
        _uiSpaceShip.SetActive(true);
        _uiSpaceShipNome.text = nome;
        _uiSpaceShipTipo.text = tipo.GetDescription();
        _uiSpaceShipDono.text = dono;
    }

    public void DesativarPanel()
    {
        _uiSpaceShip.SetActive(false);
    }
}
