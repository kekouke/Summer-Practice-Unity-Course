using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    private float _movementX;
    private float _movementY;

    public float xMin, xMax, yMin, yMax;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        _movementX = (horizontalInput * _speed);
        _movementY = (verticalInput * _speed);

        Vector3 direction = new Vector3(_movementX, _movementY, 0);

        float positionX = Mathf.Clamp(transform.position.x, xMin, xMax);
        float positionY = Mathf.Clamp(transform.position.y, yMin, yMax);

        transform.position = new Vector3(positionX, positionY, transform.position.z);

        transform.Translate(direction * Time.deltaTime);
    }
}
