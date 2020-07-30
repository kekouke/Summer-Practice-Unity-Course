using System.Runtime.Remoting.Messaging;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _gravity;
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject weapon;

    private CharacterController _controller;
    private int _coins;
    public int Money { get => _coins; }
    
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        var direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        var velocity = direction * _speed;
        velocity = transform.TransformDirection(velocity);
        velocity.y -= _gravity;
        _controller.Move(velocity * Time.deltaTime);
    }

    public void AddCoin(int coins)
    {
        _coins += coins;
        canvas.GetComponent<UIManager>().AddCoin();    
    }

    public void RemoveCoin()
    {
        _coins--;
        canvas.GetComponent<UIManager>().TakeMoney();
    } 

    public void EnableWeapon()
    {
        weapon.SetActive(true);
    } 
}
