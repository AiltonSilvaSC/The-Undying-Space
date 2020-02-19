using Assets.Scripts.Enuns;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public string Nome;
    public float População;
    public int Felicidade;
    public int Imposto;
    public Dictionary<EnumRecursos, EnumRecursos> Recursos;
    public Dictionary<EnumComponentes, EnumComponentes> Componentes;
}
