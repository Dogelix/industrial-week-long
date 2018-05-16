﻿using UnityEngine;
using Utilites;

public class ProjectileStandard : ProjectileBase
{
    int _damage;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == GameTags.Player)
        {
            DealDamage(other);
        }
    }

    public override void DealDamage(Collider playerHit)
    {
        //Do damage method on player
    }
}
