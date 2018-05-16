using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilites;

public class ShipRoll: MonoBehaviour
{
    private PlayerInput _pInput;
    [SerializeField]
    private GameObject _mesh;
    [SerializeField]
    private float _maxTilt;

    private void Start()
    {
        _pInput = gameObject.GetComponent<PlayerInput>();
    }

    private void Update()
    {
        //_mesh.transform.Rotate(Vector3.up, _pInput.HorizontalAxis);
        //_pInput.HorizontalRotation(_maxTilt)  _pInput.HorizontalRotation(_maxTilt)
    }
}
