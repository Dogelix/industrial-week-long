using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class CheckpointManager : MonoBehaviour
{
    private GameObject[] _checkpoints;

	// Use this for initialization
	void Start ()
    {
	    _checkpoints = GameObject.FindGameObjectsWithTag(GameTags.Checkpoint);
    }
	
    public int AmountOfCheckPoints
    {
        get
        {
            return _checkpoints.Length;
        }
    }
}
