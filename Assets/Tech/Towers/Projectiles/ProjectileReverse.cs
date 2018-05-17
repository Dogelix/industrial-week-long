using UnityEngine;
using Utilities;

public class ProjectileReverse : ProjectileBase
{
    // Use this for initialization
    void Start()
    {
        _type = ETower.Reverse;
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

    protected override void DealDamage(Collider playerHit)
    {
        base.DealDamage(playerHit);
    }
}
