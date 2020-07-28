using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
    CharacterController _controller;

    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _gravity;
    [SerializeField]
    private float _jumpHeight;

    private float yVelocity;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalMove, 0, 0);
        Vector3 velocity = direction * _speed;

        if (!_controller.isGrounded)
        {
            yVelocity -= _gravity;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            yVelocity = _jumpHeight;
        }

        velocity.y = yVelocity;
        _controller.Move(velocity * Time.deltaTime);
    }
       
}