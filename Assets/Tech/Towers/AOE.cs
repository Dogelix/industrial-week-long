using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilites;

public class AOE : TurretBase
 {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Tick()
    {
        base.Tick();
        //Do AOE
        AreaOfEffect();
    }

    void AreaOfEffect()
    {
        //Can tweak the radius (5) or put it in a variable later on when we know how far it will reach
        Collider[] hitPlayers = Physics.OverlapSphere(transform.position, 5.0f);
        //Do slow down effect on players, method name can be changed or code can be changed from SendMessage if needed
        foreach (Collider player in hitPlayers)
        {
            if (player.tag == GameTags.Player)
            {
                player.SendMessage("SlowDown");
            }
        }
    }
}
