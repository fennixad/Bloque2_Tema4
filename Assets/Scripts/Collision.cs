using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{

    
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.tag == "caja")
        {
            Debug.Log("Estoy chocando con una caja");
        }
    }
    
}
