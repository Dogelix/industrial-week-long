using UnityEngine;
using Utilites;

public class ProjectileStandard : ProjectileBase
{
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
}
