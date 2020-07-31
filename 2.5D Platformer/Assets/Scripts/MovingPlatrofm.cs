using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatrofm : MonoBehaviour
{
    [SerializeField]
    private Transform _pointA;
    [SerializeField]
    private Transform _pointB;

    void Update()
    {
        MovePlatform();
    }

    private void MovePlatform()
    {
        transform.position = Vector3.MoveTowards(transform.position, _pointB.position, 5 * Time.deltaTime);

        if (transform.position == _pointB.position || transform.position == _pointA.position)
        {
            (_pointA, _pointB) = (_pointB, _pointA);
        }
    }

    private void OnTriggerEnter(Collider other)
    {   
        if (other.tag == "Player")
        {
            other.gameObject.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.transform.parent = null;
        }
    }
}
