using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private AudioClip _explosionSound;
    [SerializeField]
    private GameObject _laserPrefab;

    private float _fireNext = -1;

    private Player _player;
    private Animator _enemyAnim;
    private AudioSource _audioSource;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _enemyAnim = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        Move();

        if (Time.time >= _fireNext)
        {
            GameObject enemyLaser = Instantiate(_laserPrefab, transform.position, Quaternion.identity);
            Laser[] lasers = enemyLaser.GetComponentsInChildren<Laser>();

            foreach (var laser in lasers)
            {
                laser.AssignEnemy();
            }


            _fireNext = Time.time + Random.Range(3, 8);
        }

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
    }


    public void Damage()
    {
        _audioSource.clip = _explosionSound;
        _audioSource.Play();

        _player.AddScore(10);
        _enemyAnim.SetTrigger("OnEnemyDestroy");
        Destroy(GetComponent<Collider2D>());
        Destroy(gameObject, 2.8f);
    }
}
