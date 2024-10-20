using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public TextMeshProUGUI power;
    public Camera playerCamera;
    public GameObject ball;
    public float rayDistance = 1000f;
    public float distanceBall = 1f;
    public float pushForce = 10f;
    public float barras;

    void Start()
    {
        
    }

    void Update()
    {
        RaycastInput();
    }

    void FixedUpdate()
    {
        
    }

    void BallRecognizer()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            Debug.Log($"Hit: {hit.collider.gameObject.tag}");
        }
        DrawDebugRay(ray);
    }

    void RaycastInput()
    {
        if (Input.GetKey(KeyCode.E))
        {
            BallRecognizer();
            PullingBall();
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            PushingBall();
        }
    }

    void PullingBall()
    {
        ball.transform.SetParent(playerCamera.transform);

        Vector3 newPosition = playerCamera.transform.position + playerCamera.transform.forward * distanceBall;

        ball.transform.position = newPosition;
        ball.transform.rotation = playerCamera.transform.rotation;

        ball.GetComponent<Rigidbody>().useGravity = false;
        ball.GetComponent<SphereCollider>().enabled = false;

        BallPower();
    }

    void PushingBall()
    {
        ball.GetComponent<Rigidbody>().useGravity = true;
        ball.GetComponent<SphereCollider>().enabled = true;

        ball.GetComponent<Rigidbody>().AddForce(Vector3.forward * pushForce, ForceMode.Impulse);
    }

    void DrawDebugRay(Ray ray)
    {
        Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.red, 0.1f);
    }

    void BallPower()
    {
        barras = 1 * Time.deltaTime;

        while (barras < 5)
        {
            power.text += "|";
        }
    }
}
