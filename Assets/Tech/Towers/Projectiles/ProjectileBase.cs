using System.Collections;
using UnityEngine;
using Utilities;

public class ProjectileBase : MonoBehaviour
{
    protected int _damage;
    protected ETower _type;
    Rigidbody _body;

    public ETower Type
    {
        get
        {
            return _type;
        }
        set
        {
            _type = value;
        }
    }

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
        _body = GetComponent<Rigidbody>();
        _damage = damage;
        _body.velocity = transform.forward * 20;
        StartCoroutine(KillProjectile());
    }

    IEnumerator KillProjectile()
    {
        yield return new WaitForSecondsRealtime(5.0f);
        Destroy(gameObject);
    }

    protected virtual void DealDamage(Collider playerHit)
    {
        Debug.Log("do we even get here?");
        //Damage method on player
        //based on ETower, deal correct damage, if reverse tower do reverse, default break
        switch (_type)
        {
            case ETower.StandardCannon:
                {
                    //Do damage with _damage
                    break;
                }
            case ETower.StaticCannon:
                {
                    //Do damage with _damage
                    break;
                }
            case ETower.Reverse:
                {
                    Debug.Log("is this called?");
                    playerHit.gameObject.GetComponent<PlayerInput>().Reverse(true);
                    break;
                }
            default:
                {
                    break;
                }
        }
    }
}
