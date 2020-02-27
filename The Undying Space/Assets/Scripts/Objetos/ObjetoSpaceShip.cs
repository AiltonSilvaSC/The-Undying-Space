using Assets.Scripts.Enuns;
using Pathfinding;
using UnityEngine;

public class ObjetoSpaceShip : MonoBehaviour
{
    public EnumEspaconaves TipoNave;
    public string Nome;


    public Vector3 alvo;
    public bool mover;
    private IAstarAI ai;


    private void Start()
    {
        ai = GetComponent<IAstarAI>();
        if (ai != null) ai.onSearchPath += Update;
        mover = false;
    }

    void OnDisable()
    {
        if (ai != null) ai.onSearchPath -= Update;
    }

    private void Update()
    {
        if (alvo != null && mover)
            ai.destination = alvo;
    }
}