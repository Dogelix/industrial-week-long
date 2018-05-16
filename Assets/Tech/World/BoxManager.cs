using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilites;

public class BoxManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _box;
    private GameObject[] _spawnLocations;

	// Use this for initialization
	void Start ()
    {
        _spawnLocations = GameObject.FindGameObjectsWithTag(GameTags.SpawnBox);
        InvokeRepeating("SpawnBoxes", 0, 4);
	}
	
    private void SpawnBoxes()
    {
        foreach (GameObject go in _spawnLocations)
        {
            if(go.GetComponent<InUse>().Free == true)
            {
                Instantiate(_box, go.transform);
                go.GetComponent<InUse>().Free = false;
            }
        }
    }

    public void FreeUpSpawn(GameObject point)
    {
        foreach (GameObject go in _spawnLocations)
        {
            if (go == point)
            {
                go.GetComponent<InUse>().Free = true;
                break;
            }
        }
    }
}
