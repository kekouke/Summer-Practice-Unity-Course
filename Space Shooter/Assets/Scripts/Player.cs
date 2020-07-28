using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public bool isPlayerOne;
    public bool isPlayerTwo;

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

    private SceneController _sceneController;
    private SpawnManager _spawnManager;
    private UIManager UImanager;

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
    [SerializeField]
    private AudioClip _fireSound;
    [SerializeField]
    private AudioClip _explosionSound;

    private AudioSource _audioSourse;

    void Start()
    {
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        _sceneController = GameObject.Find("SceneController").GetComponent<SceneController>();
        UImanager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _audioSourse = GetComponent<AudioSource>();

        if (_spawnManager == null)
        {
            Debug.LogError("_spawnManager is NULL");
        }

        if (_sceneController.isSingleMode)
        {
            transform.position = new Vector3(0, 0, 0);
        }
    }

    void Update() 
    {
        if (isPlayerOne)
        {
            Move("Horizontal", "Vertical");
        }
        if (isPlayerTwo)
        {
            Move("Horizontal2", "Vertical2");
        }

        if ((Input.GetKeyDown(KeyCode.Space) && isPlayerOne) || (Input.GetKeyDown(KeyCode.RightShift) && isPlayerTwo) && Time.time >= _fireNext)
        {
            Fire();
        }
    }

    void Move(string horizontalAxis, string verticalAxis)
    {
        float horizontalInput = Input.GetAxis(horizontalAxis);
        float verticalInput = Input.GetAxis(verticalAxis);

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

        _audioSourse.clip = _fireSound;
        _audioSourse.Play();
    }

    public void Damage()
    {

        if (_isShieldEnabled)
        {
            _isShieldEnabled = false;
            _shieldVisualizer.SetActive(false);
            return;
        }


        _audioSourse.clip = _explosionSound;
        _audioSourse.Play();
        _lives--;
        UImanager.UpdateLives(_lives);


        switch(_lives)
        {
            case 0:
                _spawnManager.OnPlayerDeath();
                _sceneController.Restart(true);

                Destroy(gameObject);
                break;
            case 1:
                transform.Find("LeftEngine").gameObject.SetActive(true);
                break;
            case 2:
                transform.Find("RightEngine").gameObject.SetActive(true);
                break;
        }
    }

    public void AddScore(int score)
    {
        _score += score;
        UImanager.UpdateScore(_score);
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
