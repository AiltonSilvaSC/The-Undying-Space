using Assets.Scripts.Enuns;
using UnityEngine;

public class Objeto : MonoBehaviour
{
    public EnumObjeto TipoObjeto;
    private SpriteRenderer _spriteRender;

    private void Start()
    {
        _spriteRender = GetComponent<SpriteRenderer>();
    }

    public void MostrarSelection()
    {
        _spriteRender.sortingOrder = 1;
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void DesativarSelection()
    {
        _spriteRender.sortingOrder = 0;
        gameObject.transform.GetChild(0).gameObject.SetActive(false);

    }
}
