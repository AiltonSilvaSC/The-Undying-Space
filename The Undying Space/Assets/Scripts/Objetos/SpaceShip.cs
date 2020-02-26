﻿using Assets.Scripts.Enuns;
using Pathfinding;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    public EnumEspaconaves TipoNave;
    public string Nome;


    public Transform Alvo;
    private Seeker _seeker;


    private void Start()
    {
        _seeker = GetComponent<Seeker>();
    }
   }