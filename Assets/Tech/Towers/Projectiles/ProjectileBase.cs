using UnityEngine;
using Utilities;

public class ProjectileBase : MonoBehaviour
{
    protected int _damage;
    ETower _type;

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

    }

    public void DealDamage(Collider playerHit)
    {
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
