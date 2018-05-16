using UnityEngine;
using Utilites;

public class ProjectileBase : MonoBehaviour
{
    protected int _damage;
	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public virtual void OnSpawnMove(int damage)
    {

    }

    public void DealDamage(Collider playerHit)
    {
        //Damage method on player
        //based on ETower, deal correct damage, if reverse tower do reverse, default break
    }
}
