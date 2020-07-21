﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _fireDelay;
    [SerializeField]
    private GameObject laserPrefab;

    private float _movementX;
    private float _movementY;

    private float _fireNext;


    public float yMin, yMax;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    void Update() 
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= _fireNext)
        {
            Fire();
        }

    }

    void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        _movementX = (horizontalInput * _speed);
        _movementY = (verticalInput * _speed);

        Vector3 direction = new Vector3(_movementX, _movementY, 0);

        transform.Translate(direction * Time.deltaTime);

        float positionY = Mathf.Clamp(transform.position.y, yMin, yMax);

        transform.position = new Vector3(transform.position.x, positionY, 0);

        if (transform.position.x > 9.5f)
        {
            transform.position = new Vector3(-9.5f, positionY, 0);
        }
        else if (transform.position.x < -9.5f)
        {
            transform.position = new Vector3(9.5f, positionY, 0);
        }
    }

    void Fire()
    {
        Instantiate(laserPrefab, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
        _fireNext = Time.time + _fireDelay;
    }
}
