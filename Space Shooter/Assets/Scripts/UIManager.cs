using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField]
    private Text _scoreText;

    void Start()
    {
        UpdateScore(0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateScore(int score)
    {
        _scoreText.text = "Score: " + score;
    }
}
