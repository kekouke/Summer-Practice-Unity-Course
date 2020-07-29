using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    CharacterController _controller;

    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _gravity;
    [SerializeField]
    private float _jumpHeight;
    [SerializeField]
    private GameObject gui;
    [SerializeField]
    Transform _startPosition;

    private AudioSource _coinSelected;
    private float yVelocity;
    private bool canDoubleJump;
    private int _coins;
    private int _lives = 3;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _coinSelected = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalMove, 0, 0);
        Vector3 velocity = direction * _speed;

        if (!_controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space) && canDoubleJump)
            {
                canDoubleJump = false;
                yVelocity = _jumpHeight;
                //velocity.y = _jumpHeight;
            }
            else
            {
                yVelocity -= _gravity;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            canDoubleJump = true;
            yVelocity = _jumpHeight;
        }

        velocity.y = yVelocity;
        _controller.Move(velocity * Time.deltaTime);
        
    }
       
    public void AddCoin()
    {
        _coins++;
        gui.GetComponent<UIManager>().UpdateCoinsDisplay(_coins);
        _coinSelected.Play();
    }

    public void Damage()
    {
        _lives--;
        gui.GetComponent<UIManager>().UpdateLivesDisplay(_lives);

        if (_lives <= 0)
        {
            SceneManager.LoadScene(0);
        }

        _controller.enabled = false;
        transform.position = _startPosition.position;
        _controller.enabled = true;
    }
}