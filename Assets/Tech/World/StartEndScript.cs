using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class StartEndScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameTags.Player))
        {
            PlayerFunctions playerFunctions = other.gameObject.GetComponent<PlayerFunctions>();

            if (playerFunctions.CheckpointCounter == this.Find<CheckpointManager>(GameTags.ScriptM).AmountOfCheckPoints - 1)
            {
                playerFunctions.IncrementLap();
                playerFunctions.CheckPoint = gameObject;
            }
        }
    }
}
