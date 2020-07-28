using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
    CharacterController _controller;

    [SerializeField]
    private float _speed;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalMove, 0, 0) * _speed;
        _controller.Move(direction * Time.deltaTime);
    }
}
