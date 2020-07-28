using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField]
    private Text _coinsText;

    void Awake()
    {
        UpdateCoinsDisplay(0);
    }

    public void UpdateCoinsDisplay(int coins)
    {
        _coinsText.text = "Coins: " + coins;
    }
}
