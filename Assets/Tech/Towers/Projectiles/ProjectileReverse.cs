using UnityEngine;
using Utilites;

public class ProjectileReverse : ProjectileBase
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
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
        playerHit.gameObject.GetComponent<PlayerInput>().Reverse(true);
    }
}
