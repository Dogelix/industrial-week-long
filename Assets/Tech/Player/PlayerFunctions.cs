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

    public int Lap
    {
        get
        {
            return _lap;
        }
        set
        {
            _lap = value;
        }
    }

    public GameObject CheckPoint
    {
        set
        {
            _checkPoint = value;
        }
    }

    public void Respawn()
    {
        transform.position = _checkPoint.transform.position;
    }

    private void Start()
    {
        
    }
}