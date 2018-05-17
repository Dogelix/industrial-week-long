using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class TurretBase : MonoBehaviour, ITower
{
    [SerializeField]
    ETower _towerType;
    GamePad.Index _ownedByPlayer;
    [SerializeField]
    protected int _health = 8;
    int _tickCount = 0;

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

    public virtual void Tick()
    {
        //do things
        //if ((_tickCount % 2) == 0)
        //{
        //    DecrementHealth();
        //}
        //_tickCount++;
    }

    void DecrementHealth()
    {
        _health--;
        if (_health == 0)
        {
            this.Find<TowerManager>(GameTags.ScriptM).RemoveTowerFromList(gameObject);
            Destroy(gameObject);
        }
        //Swap out sprite here
    }
}
