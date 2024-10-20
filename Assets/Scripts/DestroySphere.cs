using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyComponent : MonoBehaviour
{
    public Transform raycastOrigin;
    public float rayDistance = 10f;
    void Start()
    {

    }

    void Update() 
    {
        PerformRaycast();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.tag == "caja")
            Destroy (collider.gameObject);

    }

    void PerformRaycast ()
    {
        Ray ray = CreateRay();
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            OnRaycastHit(hit);
        }

        DrawDebugRay(ray);
    }

    Ray CreateRay()
    {
        return new Ray(raycastOrigin.position, raycastOrigin.forward);
    }

    void OnRaycastHit(RaycastHit hit)
    {
        //Debug.Log("Golpeo a: " + hit.collider.gameObject.name);
        if (hit.collider.gameObject.transform.tag == "cajaRaycast" && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(hit.collider.gameObject);
        }
    }

    void DrawDebugRay(Ray ray)
    {
        Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.red, 0.1f);
    }
}
