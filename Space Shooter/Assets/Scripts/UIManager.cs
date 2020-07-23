using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Text _gameoverText;
    [SerializeField]
    private Sprite[] _liveSprites;
    [SerializeField]
    Image _livesImage;

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

    public void UpdateLives(int currentLive)
    {
        _livesImage.sprite = _liveSprites[currentLive];

        if (currentLive <= 0)
        {
            _gameoverText.gameObject.SetActive(true);
        }

    }
}
