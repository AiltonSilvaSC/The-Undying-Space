using Assets.Scripts;
using Assets.Scripts.Entidades;
using Assets.Scripts.Enuns;
using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Planet : MonoBehaviour
{

    public string Nome { get; private set; }
    public int Imposto { get; set; }
    public float Qualidade { get; private set; } // de 0.00 a 1.00
    public float Tamanho { get; private set; }
    public EnumPlanetas Tipo { get; private set; }

    //public Dictionary<EnumRecursos, EnumRecursos> Recursos { get; private set; }

    public List<EntidadePopulacao> Populacoes { get; private set; }
    //public List<EntidadeTropa> Tropas { get; private set; }


    private void Start()
    {
        Populacoes = new List<EntidadePopulacao>();
        RandomizarPlaneta();
    }

    private void RandomizarPlaneta()
    {
        RandomizarNome.CarregarClasse();
        Nome = RandomizarNome.RandomNome();
        Debug.Log("Randomizado!");
        Qualidade = Random.Range(0.00f, 0.98f);
        Tamanho = Random.Range(1000f, 160000f);
        var v = Enum.GetValues(typeof(EnumPlanetas));
        Tipo = (EnumPlanetas)v.GetValue(Random.Range(0, v.Length));
    }
}
