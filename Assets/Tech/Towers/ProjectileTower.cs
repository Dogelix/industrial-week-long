﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class ProjectileTower : TurretBase
{
    GameObject[] _players;
    GameObject _sphere;
    GameObject _spawn;
    public ProjectileStandard _standardProjectile;
    public ProjectileReverse _reverseProjectile;
    private bool _isDelaying = false;
    // Use this for initialization
    void Start ()
    {
        _players = GameObject.FindGameObjectsWithTag(GameTags.Player);
        _sphere = transform.Find("Top").gameObject;
        _spawn = transform.Find("Top/ProjectileSpawn").gameObject;
    }
	
	// Update is called once per frame
	void Update ()
    {
    }

    public override void Tick()
    {
        base.Tick();
        //Do projectile for static tower
        if (TowerType == ETower.StaticCannon)
        {
            ProjectileStandard projectile = (ProjectileStandard)Instantiate(_standardProjectile, _spawn.transform.position, _spawn.transform.rotation);
            projectile.Type = ETower.StandardCannon;
            projectile.OnSpawnMove(4);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!_isDelaying)
        {
            switch (TowerType)
            {
                case ETower.StandardCannon:
                    {
                        Vector3 correctTarget = new Vector3(FollowClosestPlayer().transform.position.x, _sphere.transform.position.y, FollowClosestPlayer().transform.position.z);
                        _sphere.transform.LookAt(correctTarget);
                        ProjectileStandard projectile = (ProjectileStandard)Instantiate(_standardProjectile, _spawn.transform.position, _spawn.transform.rotation);
                        projectile.Type = ETower.StandardCannon;
                        projectile.OnSpawnMove(1);
                        _isDelaying = true;
                        StartCoroutine(WaitSeconds(0.5f));
                        break;
                    }
                case ETower.Reverse:
                    {
                        Vector3 correctTarget = new Vector3(FollowClosestPlayer().transform.position.x, _sphere.transform.position.y, FollowClosestPlayer().transform.position.z);
                        _sphere.transform.LookAt(correctTarget);
                        ProjectileStandard projectile = (ProjectileStandard)Instantiate(_standardProjectile, _spawn.transform.position, _spawn.transform.rotation);
                        projectile.Type = ETower.StandardCannon;
                        projectile.OnSpawnMove(0);
                        _isDelaying = true;
                        StartCoroutine(WaitSeconds(0.5f));
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
    }

    IEnumerator WaitSeconds(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        _isDelaying = false;
    }

    public GameObject FollowClosestPlayer()
    {

        GameObject closest = null;
        float temp;
        float curDistance = Mathf.Infinity;
        foreach (GameObject player in _players)
        {
            temp = Vector3.Distance(player.transform.position, transform.position);
            if (temp < curDistance && (!(OwnedByPlayer == player.GetComponent<PlayerInput>().PlayerNumber)))
            {
                closest = player;
                curDistance = temp;
            }
        }
        return closest;
    }
}
