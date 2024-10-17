using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsTrigger : MonoBehaviour
{
    public Transform transform;
    void Start()
    {
        
    }
    
    void OnTriggerEnter(Collider collider) { 

        if (collider.tag == "caja") 
        {
            Destroy(collider.gameObject);
            transform.localScale = new Vector3(4f, 4f, 4f);

        } else if (collider.tag == "AntiFall")
        {
            Debug.Log("traspaso pared invisible");
            transform.position = new Vector3(0f, 0f, 0f);
        } else if (collider.tag == "cajaMagica")
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
    
}
