using Assets.Scripts.Enuns;
using UnityEngine;
using UnityEngine.UI;

public class Objeto : MonoBehaviour
{
    public EnumObjetos tipoObjeto;
    public int idJogadorAtual;
    private int idJogadorAnterior;

    private GameObject _circuloDono;
    private GameObject _circuloSelecao;

    private void Start()
    {
        _circuloSelecao = gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
        _circuloDono = gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
        _circuloSelecao.SetActive(false);
        _circuloDono.SetActive(false);
    }

    public void MostrarSelection()
    {
        GetComponent<SpriteRenderer>().sortingOrder = 1;
        _circuloSelecao.SetActive(true);
    }

    public void DesativarSelection()
    {
        GetComponent<SpriteRenderer>().sortingOrder = 0;
        _circuloSelecao.SetActive(false);
    }

    private void Update()
    {
        // se for igual rotaciona
        if (idJogadorAtual != 0 && idJogadorAnterior == idJogadorAtual)
        {
            _circuloDono.GetComponent<RectTransform>().Rotate(0, 0, 3 * Time.deltaTime);
            // se for diferente, atualiza a cor.
        }
        else if (idJogadorAnterior != idJogadorAtual)
        {
            idJogadorAnterior = idJogadorAtual;
            if (idJogadorAtual == 0)
            {
                _circuloDono.SetActive(false);
                return;
            }
            else
                _circuloDono.SetActive(true);
            _circuloDono.GetComponent<Image>().color = GameControl.instance.jogadores[idJogadorAtual].imperioCor;

        }
        if (_circuloSelecao.activeSelf)
            _circuloSelecao.transform.Rotate(0, 0, 24 * Time.deltaTime);
    }
}
