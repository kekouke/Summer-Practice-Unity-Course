using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text ammo;
    void Start()
    {
        DisplayAmmo(0);
    }

    public void DisplayAmmo(int pistol)
    {
        ammo.text = "Ammo: " + pistol;
    }
}
