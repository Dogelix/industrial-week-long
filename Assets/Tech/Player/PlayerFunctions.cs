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
    private int _lap;
    private int _health = 8;
    private int _position = 1;

    private IGUIController _ui;

    public int Lap
    {
        get
        {
            return _lap;
        }
        set
        {
            _lap = value;
            _ui.SetLap(_lap);
        }
    }

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