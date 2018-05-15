using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : TurretBase
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
        //Do projectile for static tower
    }

    private void OnTriggerStay(Collider other)
    {
        transform.LookAt(FollowClosestPlayer().transform, Vector3.up);
    }

    public GameObject FollowClosestPlayer()
    {
        GameObject[] players;
        players = GameObject.FindGameObjectsWithTag("Player");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject player in players)
        {
            Vector3 diff = player.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = player;
                distance = curDistance;
            }
        }
        return closest;
    }
}
