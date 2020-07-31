using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    [SerializeField] GameObject destroedCrate;

    public void DestroyCrate()
    {
        Instantiate(destroedCrate, transform.position, transform.rotation);
        Destroy(gameObject);
    }

}
