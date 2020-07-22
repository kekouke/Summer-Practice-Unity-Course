using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private int _speed;
    [SerializeField]
    private int _id;

    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.gameObject.GetComponent<Player>();
            switch(_id)
            {
                case 0:
                    player.TripleShotActive();
                    break;
                case 1:
                    player.SpeedBoostActive();
                    break;
                case 2:
                    player.ShieldActive();
                    break;
            }
            Destroy(gameObject);
        }
    }  
}
