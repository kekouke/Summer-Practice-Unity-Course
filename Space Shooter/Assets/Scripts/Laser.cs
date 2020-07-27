using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    private bool _isEnemyLaser;
 
    void Update()
    {
        if (_isEnemyLaser)
        {
            Move(Vector3.down);
        }
        else
        {
            Move(Vector3.up);
        }
    }

    void Move(Vector3 direction)
    {
        transform.Translate(direction * _speed * Time.deltaTime);
    }

    public void AssignEnemy()
    {
        _isEnemyLaser = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && _isEnemyLaser)
        {
            other.GetComponent<Player>().Damage();
            Destroy(gameObject);
        }
        else if (other.tag == "Enemy" && !_isEnemyLaser)
        {
            other.GetComponent<Enemy>().Damage();
            Destroy(gameObject);
        }
    }

}
