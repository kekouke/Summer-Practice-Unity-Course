using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    private Player _player;
    private Animator _enemyAnim;

    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        _enemyAnim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -5)
        {
            transform.position = new Vector3(Random.Range(-8, 8), 7, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().Damage();
            _enemyAnim.SetTrigger("OnEnemyDestroy");
            Destroy(GetComponent<Collider2D>());
            Destroy(gameObject, 2.8f);
        }
        else if (other.tag == "Laser")
        {
            Destroy(other.gameObject);

            _player.AddScore(10);
            _enemyAnim.SetTrigger("OnEnemyDestroy");
            Destroy(GetComponent<Collider2D>());
            Destroy(gameObject, 2.8f);
        }
    }
}
