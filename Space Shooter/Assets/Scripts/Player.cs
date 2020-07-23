using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _fireDelay;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _tripleShotPrefab;
    [SerializeField]
    private int _lives;

    private SpawnManager _spawnManager;

    private float _movementX;
    private float _movementY;

    private float _fireNext;

    [SerializeField]
    private int _score;

    private bool _isTripleShotEnabled;
    private bool _isShieldEnabled;

    public float yMin, yMax;

    [SerializeField]
    private GameObject _shieldVisualizer;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

        if (_spawnManager == null)
        {
            Debug.LogError("_spawnManager is NULL");
        }
    }

    void Update() 
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= _fireNext)
        {
            Fire();
        }

    }

    void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        _movementX = (horizontalInput * _speed);
        _movementY = (verticalInput * _speed);

        Vector3 direction = new Vector3(_movementX, _movementY, 0);

        transform.Translate(direction * Time.deltaTime);

        float positionY = Mathf.Clamp(transform.position.y, yMin, yMax);

        transform.position = new Vector3(transform.position.x, positionY, 0);

        if (transform.position.x > 9.5f)
        {
            transform.position = new Vector3(-9.5f, positionY, 0);
        }
        else if (transform.position.x < -9.5f)
        {
            transform.position = new Vector3(9.5f, positionY, 0);
        }
    }

    void Fire()
    {
        if (_isTripleShotEnabled)
        {
            Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 1.05f, 0), Quaternion.identity);
        }
        _fireNext = Time.time + _fireDelay;
    }

    public void Damage()
    {

        if (_isShieldEnabled)
        {
            _isShieldEnabled = false;
            _shieldVisualizer.SetActive(false);
            return;
        }

        _lives--;

        if (_lives <= 0)
        {
            _spawnManager.OnPlayerDeath();
            Destroy(gameObject);
        }
    }

    public void AddScore(int score)
    {
        _score += score;
        GameObject.Find("Canvas").GetComponent<UIManager>().UpdateScore(_score);
    }

    public void TripleShotActive()
    {
        _isTripleShotEnabled = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }

    public void SpeedBoostActive()
    {
        _speed *= 2;
        StartCoroutine(SpeedBoostDownRoutine());

    }

    public void ShieldActive()
    {
        _isShieldEnabled = true;
        _shieldVisualizer.SetActive(true);
    }

    IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5);
        _isTripleShotEnabled = false;
    }

    IEnumerator SpeedBoostDownRoutine()
    {
        yield return new WaitForSeconds(5);
        _speed /= 2;
    }
}
