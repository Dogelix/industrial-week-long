using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilites;

public class TurretBase : MonoBehaviour, ITower
{
    ETower _towerType;
    GamePad.Index _ownedByPlayer;
    protected int _health = 8;

    public GamePad.Index OwnedByPlayer
    {
        get
        {
            return _ownedByPlayer;
        }
        set
        {
            _ownedByPlayer = value;
        }
    }

    public ETower TowerType
    {
        get
        {
            return _towerType;
        }
    }

    public void Tick()
    {
        //do things
        Debug.Log("BASE TICK");
        DecrementHealth();
    }

    void DecrementHealth()
    {
        _health--;
        //Swap out sprite here
    }
}
