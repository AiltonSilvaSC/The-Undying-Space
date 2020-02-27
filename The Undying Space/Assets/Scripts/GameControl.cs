using Assets.Scripts.Entidades;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public int idJogador;

    public string imperioNome;

    public Color imperioCor;

    public float dinheiroDisponivel;

    public Dictionary<int, EntidadeJogador> jogadores;

    public static GameControl instance;

    [SerializeField]
    private CameraDrag _cameraDrag;
    [SerializeField]
    private ZoomControl _zoomControl;
    [SerializeField]
    private ClickManager _clickManager;

    private void Awake()
    {
        jogadores = new Dictionary<int, EntidadeJogador>();
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        var jogador = new EntidadeJogador()
        {
            idJogador = this.idJogador,
            imperioNome = this.imperioNome,
            imperioCor = this.imperioCor,
            dinheiroDisponivel = this.dinheiroDisponivel
        };
        jogadores.Add(1, jogador);
    }

    public void PausarGame(bool pausar)
    {
        if (pausar == true)
            pausar = false;
        else
            pausar = true;
        _cameraDrag.funcionar = pausar;
        _zoomControl.funcionar = pausar;
        _clickManager.Funcionar = pausar;
        switch (pausar)
        {
            case false:
                Time.timeScale = 0;
                break;
            case true:
                Time.timeScale = 1;
                break;
        }
    }
}

