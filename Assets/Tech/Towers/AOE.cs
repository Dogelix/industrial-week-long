using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilites;

public class AOE : TurretBase
 {
    float _radius = 15.0f;
    float _slowTime = 2.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Tick()
    {
        //Do AOE
        AreaOfEffect();
        base.Tick();
    }

    void AreaOfEffect()
    {
        //Can tweak the radius (5) or put it in a variable later on when we know how far it will reach
        Collider[] hitPlayers = Physics.OverlapSphere(transform.position, _radius);
        //Do slow down effect on players, method name can be changed or code can be changed from SendMessage if needed
        foreach (Collider player in hitPlayers)
        {
            if (player.tag == GameTags.Player)
            {
                Debug.Log("Player slowed");
                player.gameObject.GetComponent<PlayerInput>().SlowDown(true, _slowTime);
            }
        }
    }
}
