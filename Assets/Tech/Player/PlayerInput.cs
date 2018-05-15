using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilites;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10.0f;
    [SerializeField]
    private float _speedCap = 200.0f;
    [SerializeField]
    private float _rotationForce = 1.0f;
    [SerializeField]
    private GamePad.Index _playerNumber;
    
    private bool _isReversed = false;

	// Use this for initialization
	void Start ()
    {
        gameObject.GetComponent<CameraController>().SetUpCameraSize(_playerNumber, false);
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

    public void Reverse(bool towerHit)
    {
        _isReversed = !_isReversed;
        if (towerHit)
            StartCoroutine(StartWaitForReverse(2));
    }

    private void Movement()
    {
        float step = 0;
        var trig = GamePad.GetTrigger(GamePad.Trigger.RightTrigger, _playerNumber);
        if (trig > 0)
        {
            step = trig * _speed * Time.deltaTime;
        }

        float rotation;
        if (!_isReversed)
            rotation = GamePad.GetAxis(GamePad.Axis.LeftStick, _playerNumber).x;
        else
            rotation = -GamePad.GetAxis(GamePad.Axis.LeftStick, _playerNumber).x;
        transform.Rotate(Vector3.up, rotation * _rotationForce);
        transform.Translate(0, 0, 1 * step);
        
    }

    private IEnumerator StartWaitForReverse(float time)
    {
        yield return new WaitForSeconds(time);
        Reverse(false);
    }
}
