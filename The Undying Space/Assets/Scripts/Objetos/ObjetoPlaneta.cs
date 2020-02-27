using Assets.Scripts;
using Assets.Scripts.Entidades;
using Assets.Scripts.Enuns;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjetoPlaneta : MonoBehaviour
{

    public string nome;

    [HideInInspector]
    public int imposto;

    [Range(0.10f, 0.98f)]
    public float qualidade; // de 0.00 a 1.00

    [Range(2000f, 300000f)]
    public float tamanho;

    public EnumPlanetas tipo;

    //public Dictionary<EnumRecursos, EnumRecursos> Recursos { get; private set; }

    public List<EntidadePopulacao> populacoes;
    //public List<EntidadeTropa> Tropas { get; private set; }

    public List<string> producaoNaves;

    public GameObject nave;

    public void RandomizarPlaneta()
    {
        RandomizarNome.CarregarClasse();
        nome = RandomizarNome.RandomNome();
        Debug.Log("Randomizado!");
        qualidade = Random.Range(0.00f, 0.98f);
        tamanho = Random.Range(1000f, 160000f);
        var v = Enum.GetValues(typeof(EnumPlanetas));
        tipo = (EnumPlanetas)v.GetValue(Random.Range(0, v.Length));
    }

    private void Start()
    {
        StartCoroutine(CriarNave());
    }

    IEnumerator CriarNave()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            if (producaoNaves.Count != 0)
            {
                yield return new WaitForSeconds(8f);
                producaoNaves.RemoveAt(0);
                Instantiate(nave, transform.position, Quaternion.identity);
            }
        }
    }
}
