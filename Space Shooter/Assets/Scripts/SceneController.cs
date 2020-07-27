using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    [SerializeField]
    private GameObject _player;
    [SerializeField]
    GameObject _pauseObject;

    public bool isSingleMode;
    private bool _gameStatus;

    void Awake()
    {
        if (isSingleMode)
        {
            Instantiate(_player, Vector3.zero, Quaternion.identity);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && _gameStatus && isSingleMode)
        {
            SceneManager.LoadScene(1);
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
        else if (Input.GetKeyDown(KeyCode.R) && !isSingleMode && _gameStatus)
        {
            SceneManager.LoadScene(2);
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        //_pauseObject.GetComponent<PauseMenu>().SetPause();

        if (isSingleMode && Input.GetKeyDown(KeyCode.P)) {
            _pauseObject.SetActive(true);
            Time.timeScale = 0;
        }

    }

    public void Restart(bool status)
    {
        _gameStatus = status;
    }

}
