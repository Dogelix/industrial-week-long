using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    private List<GameObject> _towers = new List<GameObject>();
    [SerializeField]
    private GameObject[] _spawnLocations;

    private void Start()
    {
        InvokeRepeating("DoTick", 0.0f, 1.0f);
    }

    private void DoTick()
    {
        foreach (GameObject obj in _towers)
        {
            obj.GetComponent<ITower>().Tick();
        }
    }
}