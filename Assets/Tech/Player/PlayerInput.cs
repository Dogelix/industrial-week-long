using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilites;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10.0f;
    [SerializeField]
    private float _rotationForce = 1.0f;
    [SerializeField]
    private float _maxTilt;
    [SerializeField]
    private GamePad.Index _playerNumber;

    private bool _isReversed = false;
    private bool _isSlowed = false;

    [SerializeField]
    //Inventory Stuff
    private GameObject[] _towers = new GameObject[4] { null, null, null, null };

	// Use this for initialization
	void Start ()
    {
        gameObject.GetComponentInChildren<CameraController>().SetUpCameraSize(_playerNumber, false);
    }
	
	// Update is called once per frame
	void Update ()
    {
        Movement();
        CheckForTowerPlace();
    }

    public GamePad.Index PlayerNumber
    {
        set
        {
            _playerNumber = value;
        }
    }

    #region Movement and Rotation
    public void Reverse(bool towerHit)
    {
        _isReversed = !_isReversed;
        if (towerHit)
            StartCoroutine(StartWaitForReverse(2));
    }

    public void SlowDown(bool towerHit, float length)
    {
        _isSlowed = !_isSlowed;
        if (towerHit)
            StartCoroutine(StartWaitForSlow(length));
    }

    private void Movement()
    {
        float step = 0;
        var trig = GamePad.GetTrigger(GamePad.Trigger.RightTrigger, _playerNumber);
        if (trig > 0)
        {
            step = trig * _speed * Time.deltaTime;

            if (_isSlowed)
                step = step / 2;

            float rotation;
            if (!_isReversed)
                rotation = GamePad.GetAxis(GamePad.Axis.LeftStick, _playerNumber).x;
            else
                rotation = -GamePad.GetAxis(GamePad.Axis.LeftStick, _playerNumber).x;

            transform.Rotate(Vector3.up, rotation * _rotationForce);
        }
        
        transform.Translate(0, 0, 1 * step);   
    }

    private IEnumerator StartWaitForReverse(float time)
    {
        yield return new WaitForSeconds(time);
        Reverse(false);
    }

    private IEnumerator StartWaitForSlow(float time)
    {
        yield return new WaitForSeconds(time);
        SlowDown(false, 0.0f);
    }
    #endregion

    #region Tower Spawning
    public void AddTowerToInv(GameObject tower)
    {
        for (int i =0; i < 4; i++)
        {
            if(_towers[i] == null)
            {
                _towers[i] = tower;
                break;
            }
        }
    }

    private void RemoveTower(int location)
    {
        _towers[location] = null;
    }

    private void CheckForTowerPlace()
    {
        int i = 5;

        if(GamePad.GetButton(GamePad.Button.X, _playerNumber))
            i = 0;
        if (GamePad.GetButton(GamePad.Button.A, _playerNumber))
            i = 1;
        if (GamePad.GetButton(GamePad.Button.B, _playerNumber))
            i = 2;
        if (GamePad.GetButton(GamePad.Button.Y, _playerNumber))
            i = 3;

        if (i <= 3 && _towers[i] != null)
        {
            GameObject temp = _towers[i];
            _towers[i] = null;
            TowerManager tM = this.Find<TowerManager>(GameTags.ScriptM);
            tM.SpawnTower(temp, _playerNumber);            
        }
    }
    #endregion
}
