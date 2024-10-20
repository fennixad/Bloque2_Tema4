using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformController : MonoBehaviour
{
    public Transform player;
    private Transform originalParent;
    private Vector3 startPosition;
    void Start()
    {
        //player = this.transform;
        originalParent = player.parent;
        startPosition = player.position;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTrigerEnter");
        if (other.transform == player)
        {
            Debug.Log("OnTrigerEnter en el if");
            transform.parent = other.transform;
        }

        if (other.CompareTag("DeathZone"))
        {
            Debug.Log("Has palmado!");
            player.position = startPosition;
        }

        if (other.CompareTag("caja"))
        {
            Debug.Log("Parte 1 Completada");
            player.position = new Vector3(0f, 0f, 23.5f);
        }
    }

    void OnTriggerExit(Collider other)
    {
        //Debug.Log("OnTriggerExit");
        if (other.transform == player)
        {
            //Debug.Log("OnTrigerExit en el if");
            transform.parent = originalParent;
        }
    }
}
