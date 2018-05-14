using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilites;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private float _accelerationForce = 10.0f;
    [SerializeField]
    private float _rotationForce = 3.0f;
    [SerializeField]
    private GamePad.Index _playerNumber;
    private Rigidbody rigidbody;

	// Use this for initialization
	void Start ()
    {
        rigidbody = this.Find(GameTags.Player).GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Movement();
    }

    public GamePad.Index PlayerNumber
    {
        set
        {
            _playerNumber = value;
        }
    }

    private void Movement()
    {
        float step = 0;

        if (GamePad.GetTrigger(GamePad.Trigger.RightTrigger, _playerNumber) > 0)
        {
            step = _accelerationForce * Time.deltaTime;
        }

        float rotation = GamePad.GetAxis(GamePad.Axis.LeftStick, _playerNumber).x;
        rigidbody.AddTorque(0, rotation * _rotationForce, 0);
        rigidbody.AddForce(transform.forward * step);
    }
}
