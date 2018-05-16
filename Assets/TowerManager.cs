using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilites;

public class TowerManager : MonoBehaviour
{
    private List<GameObject> _towers = new List<GameObject>();
    private GameObject[] _spawnLocations;

    private void Start()
    {
        InvokeRepeating("DoTick", 0.0f, 1.0f);
        _spawnLocations = GameObject.FindGameObjectsWithTag(GameTags.SpawnTower);
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
        int rand = -1;
        rand = Random.Range(0, _spawnLocations.Length);
        while (_spawnLocations[rand].GetComponent<InUse>().Free == false)
        {
            rand = Random.Range(0, _spawnLocations.Length);
        }

        GameObject temp = Instantiate(tower, _spawnLocations[rand].transform);
        _spawnLocations[rand].GetComponent<InUse>().Free = false;

        temp.GetComponent<ITower>().OwnedByPlayer = owner;

        _towers.Add(temp);
    }

    public void RemoveTowerFromList(GameObject tower)
    {
        tower.transform.parent.gameObject.GetComponent<InUse>().Free = true;
        _towers.Remove(tower);
    }
}