using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilites;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == GameTags.Player)
        {
            PlayerFunctions pFunc = other.gameObject.GetComponent<PlayerFunctions>();

            pFunc.CheckPoint = gameObject;
        }
    }
}
