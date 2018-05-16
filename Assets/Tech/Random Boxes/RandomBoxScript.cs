
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilites;


public class RandomBoxScript : MonoBehaviour 
{

    [SerializeField]
    private GameObject[] _towers;

    private void OnTriggerEnter(Collider c)
    {
        GameObject temp;
        if (c.tag == GameTags.Player)
        {
            temp = c.gameObject;
            temp.GetComponent<PlayerInput>().AddTowerToInv(_towers[Random.Range(0, _towers.Length)]);
            Destroy(gameObject);
            this.Find<BoxManager>(GameTags.ScriptM).FreeUpSpawn(gameObject.transform.parent.gameObject);
        }
    }
}