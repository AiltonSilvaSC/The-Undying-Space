using Assets.Scripts.Entidades;
using Assets.Scripts.Enuns;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField]
    private string _nome;
    public string Nome { get { return _nome; } }

    public List<EntidadePopulacao> Populacoes { get; set; }
}
