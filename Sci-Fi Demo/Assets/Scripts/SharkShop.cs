using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkShop : MonoBehaviour
{
    [SerializeField] private AudioClip _sharkShop;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            Player player = other.GetComponent<Player>();

            if (player.Money > 0)
            {
                player.RemoveCoin();
                player.EnableWeapon();
                AudioSource.PlayClipAtPoint(_sharkShop, transform.position);
            }

        }
    }
}
