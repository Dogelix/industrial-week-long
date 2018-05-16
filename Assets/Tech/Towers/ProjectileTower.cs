using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilites;

public class ProjectileTower : TurretBase
{
    GameObject[] _players;
    GameObject _sphere;
    public ProjectileStandard _standardProjectile;
    public ProjectileReverse _reverseProjectile;
    // Use this for initialization
    void Start ()
    {
        _players = GameObject.FindGameObjectsWithTag(GameTags.Player);
        _sphere = transform.Find("Top").gameObject;
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
            ProjectileStandard projectile = (ProjectileStandard)Instantiate(_standardProjectile, _sphere.transform.position, _sphere.transform.rotation);
            projectile.Type = ETower.StaticCannon;
            projectile.OnSpawnMove(4);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        switch (TowerType)
        {
            case ETower.StandardCannon:
                {
                    Vector3 correctTarget = new Vector3(FollowClosestPlayer().transform.position.x, _sphere.transform.position.y, FollowClosestPlayer().transform.position.z);
                    _sphere.transform.LookAt(correctTarget);
                    ProjectileStandard projectile = (ProjectileStandard)Instantiate(_standardProjectile, _sphere.transform.position, _sphere.transform.rotation);
                    projectile.Type = ETower.StandardCannon;
                    projectile.OnSpawnMove(1);
                    break;
                }
            case ETower.Reverse:
                {
                    Vector3 correctTarget = new Vector3(FollowClosestPlayer().transform.position.x, _sphere.transform.position.y, FollowClosestPlayer().transform.position.z);
                    _sphere.transform.LookAt(correctTarget);
                    ProjectileReverse projectile = (ProjectileReverse)Instantiate(_reverseProjectile, _sphere.transform.position, _sphere.transform.rotation);
                    projectile.Type = ETower.Reverse;
                    projectile.OnSpawnMove(0);
                    break;
                }
            default:
                {
                    break;
                }
        }
    }

    public GameObject FollowClosestPlayer()
    {

        GameObject closest = null;
        float temp;
        float curDistance = Mathf.Infinity;
        foreach (GameObject player in _players)
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
