using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField]
    private Text _coinsText;
    [SerializeField]
    private Text _livesText;

    void Awake()
    {
        UpdateCoinsDisplay(0);
        UpdateLivesDisplay(3);
    }

    public void UpdateCoinsDisplay(int coins)
    {
        _coinsText.text = "Coins: " + coins;
    }

    public void UpdateLivesDisplay(int lives)
    {
        _livesText.text = "Lives: " + lives;
    }
}
