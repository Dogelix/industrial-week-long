using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*TO DO in this class:
* 1. Keep track of lap
* 2. Keep track of last checkpoint - /
* 4. Figure out ranking
*/

public class PlayerFunctions : MonoBehaviour
{
    [SerializeField]
    private GameObject _checkPoint;
    private int _lap = 1;
    private int _checkpointCounter;
    private int _health = 8;
    private int _position = 1;

    private IGUIController _ui;

    #region Basic Properties and Damage

    public int Position
    {
        get
        {
            return _position;
        }
        set
        {
            _position = value;
            _ui.SetPosition(_position);
        }
    }

    public GameObject CheckPoint
    {
        set
        {
            _checkPoint = value;
        }
    }

    public void ApplyDamage(int damage)
    {
        _health = _health - damage;

        if(_health < 1)
        {
            Respawn();
        }

        _ui.SetHealth(_health);
    }
    #endregion

    #region Laps

    public void IncrementLap()
    {
        _lap++;
        ResetCheckpointCounter();
        _ui.SetLap(_lap);
    }

    public int CheckpointCounter
    {
        get
        {
            return _checkpointCounter;
        }
    }

    public void IncrementCheckpointCounter(GameObject point)
    {
        _checkpointCounter++;
    }

    public void ResetCheckpointCounter()
    {
        _checkpointCounter = 0;
    }

    public void ResetLaps()
    {
        _lap = 1;
    }

    #endregion

    public void Respawn()
    {
        transform.position = _checkPoint.transform.position;
        _health = 8;
        _ui.SetHealth(_health);
    }

    private void Start()
    {
        _ui = GetComponentInChildren<IGUIController>();
    }
}