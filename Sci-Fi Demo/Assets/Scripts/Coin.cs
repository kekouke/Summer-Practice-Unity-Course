using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] AudioClip _coinPickUp;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            AudioSource.PlayClipAtPoint(_coinPickUp, transform.position);
            other.GetComponent<Player>().AddCoin(1);
            Destroy(gameObject);
        }
    }
}
