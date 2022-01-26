using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    [Range (2,100)]
    private float speed = 4;
    private Vector3 _targetPosition;
    private bool _isMoving = false;

    void FixedUpdate()
    {   
        if (Input.GetMouseButton(0))
        {
            SetTargetPosition();
        }

        if (_isMoving)
        {
            Move();
        }
    }

    void SetTargetPosition()
    {
        _targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _targetPosition.z = transform.position.z;
        _isMoving = true;
    }

    void Move()
    {
        //transform.rotation = Quaternion.LookRotation(Vector3.forward, _targetPosition);
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, speed * Time.deltaTime);
        if (transform.position == _targetPosition)
        {
            _isMoving = false;
        }
    }
}
