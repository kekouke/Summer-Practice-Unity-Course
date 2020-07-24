using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private AudioClip _explosionSound;

    private Player _player;
    private Animator _enemyAnim;
    private AudioSource _audioSource;

    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        _enemyAnim = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
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

            _audioSource.clip = _explosionSound;
            _audioSource.Play();

            other.gameObject.GetComponent<Player>().Damage();
            _enemyAnim.SetTrigger("OnEnemyDestroy");
            Destroy(GetComponent<Collider2D>());
            Destroy(gameObject, 2.8f);
        }
        else if (other.tag == "Laser")
        {

            _audioSource.clip = _explosionSound;
            _audioSource.Play();

            Destroy(other.gameObject);

            _player.AddScore(10);
            _enemyAnim.SetTrigger("OnEnemyDestroy");
            Destroy(GetComponent<Collider2D>());
            Destroy(gameObject, 2.8f);
        }

    }
}
