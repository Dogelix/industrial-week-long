using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class StartEndScript : MonoBehaviour
{
    private CheckpointManager checkpointManager;

    private void Start()
    {
        checkpointManager = this.Find<CheckpointManager>(GameTags.ScriptM);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == GameTags.Player)
        {
            PlayerFunctions playerFunctions = other.gameObject.GetComponent<PlayerFunctions>();

            if (playerFunctions.CheckpointCounter == checkpointManager.AmountOfCheckPoints)
            {
                playerFunctions.IncrementLap();
                playerFunctions.CheckPoint = gameObject;
            }
        }
    }
}
