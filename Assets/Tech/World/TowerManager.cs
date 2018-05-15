using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilites;

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

    public void SpawnTower(GameObject tower, GamePad.Index owner)
    {
        GameObject temp = Instantiate(tower, _spawnLocations[Random.Range(0, _spawnLocations.Length)].transform);

        temp.GetComponent<ITower>().OwnedByPlayer = owner;

        _towers.Add(temp);
    }

    public void RemoveTowerFromList(GameObject tower)
    {
        _towers.Remove(tower);
    }
}