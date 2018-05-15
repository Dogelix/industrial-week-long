using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilites;

public class ProjectileTower : TurretBase
{
    GameObject[] players;
    // Use this for initialization
    void Start ()
    {
        players = GameObject.FindGameObjectsWithTag(GameTags.Player);
    }
	
	// Update is called once per frame
	void Update ()
    {
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

        GameObject closest = null;
        float temp;
        float curDistance = Mathf.Infinity;
        foreach (GameObject player in players)
        {
            temp = Vector3.Distance(player.transform.position, transform.position);
            if (temp < curDistance)
            {
                closest = player;
                curDistance = temp;
            }
        }
        return closest;
    }
}
