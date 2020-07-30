using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _gravity;

    private CharacterController _controller;
    private int _coins;
    
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
    }
}
