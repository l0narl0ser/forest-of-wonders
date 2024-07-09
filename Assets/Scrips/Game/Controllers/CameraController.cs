using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    private Vector3 _targetPoint = Vector3.zero;
    private float _moveSpeed = 2f;
    private float _lookAheadDistance = 2f;
    private float _lookAheadSpeed = 2f;
    private float _lookOffset;
    private void Start()
    {
        _targetPoint = new Vector3(_playerController.transform.position.x, transform.position.y,
            transform.position.z);
    }

    private void LateUpdate()
    {
        if (_playerController.rigidBody.velocity.x > 0f)
        {
            _lookOffset = Mathf.Lerp(_lookOffset, _lookAheadDistance, _lookAheadSpeed * Time.deltaTime);
        }
        else if (_playerController.rigidBody.velocity.x < 0f)
        {
            _lookOffset = Mathf.Lerp(_lookOffset, -_lookAheadDistance, _lookAheadSpeed * Time.deltaTime);
        }

        _targetPoint.x = _playerController.transform.position.x + _lookOffset;
        transform.position = Vector3.Lerp(transform.position, _targetPoint, _moveSpeed * Time.deltaTime);
    }
}