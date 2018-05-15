using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laps : MonoBehaviour {

    public int laps = 0;
    public bool canFinish = false;
    public bool won = false;
    private List<GameObject> checkpoints = new List<GameObject>();
    
        

    private int playerLap = 0;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {


    }
    public void CheckPoint(GameObject checkpoint)
    {
        checkpoints.Add(checkpoint);
    }

    private void Checkpoint()
    {
        int check = 0;
        int passed = 0;
        foreach (GameObject checkp in checkpoints)
        {
            check++;
            if (checkp == true)
            {
                passed++;
            }
        }

        if (passed == check)
        {
            canFinish = true;
        }
    }

    private void Lap()
    {
        if (canFinish == true)
        {
            laps++;
            canFinish = false;

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
