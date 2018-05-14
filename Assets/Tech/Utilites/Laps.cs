using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laps : MonoBehaviour {

    public int laps = 0;
    public bool CanFinish = false;
    public bool won = false;

    private int playerLap = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {


    }

    private void Lap()
    {
        if (CanFinish == true)
        {
            laps++;
            CanFinish = false;

            if (laps >= 4)
            {
                won = true;
            }
        }
    }

    private void Trophy()
    {
        if (won == true)
        {

        }
    }
}
