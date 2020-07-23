using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    private bool _gameStatus;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r") && _gameStatus)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void Restart(bool status)
    {
        _gameStatus = status;
    }

}
