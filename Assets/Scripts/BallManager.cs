using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public TextMeshProUGUI power;
    public Camera playerCamera;
    public GameObject ball;
    public GameObject mirilla;
    public float rayDistance = 1000f;
    public float distanceBall = 1f;
    public float pushForce = 10f;
    private float barras;
    private float tiempoTranscurrido;
    private Vector3 ballInitialPosition;

    void Start()
    {
        mirilla.GetComponent<Collider>().enabled = false;

        barras = 0f;
        power.text = string.Empty;
        ballInitialPosition = ball.transform.position;
    }

    void Update()
    {
        RaycastInput();
        BallPower();
    }

    void FixedUpdate()
    {
        FallingBallReset();
    }

    void BallRecognizer()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            if (hit.transform.tag == "Ball")
            {
                ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
                ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                PullingBall();
            }
        }
    }

    void RaycastInput()
    {
        if (Input.GetKey(KeyCode.E))
        {
            BallRecognizer();
            
        }

        if (Input.GetKeyUp(KeyCode.E) && ball.transform.parent == playerCamera.transform)
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

        
    }

    void PushingBall()
    {
        ball.transform.SetParent(null);
        ball.GetComponent<SphereCollider>().enabled = true;
        ball.GetComponent<Rigidbody>().useGravity = true;
        
        ball.GetComponent<Rigidbody>().AddForce(playerCamera.transform.forward * pushForce, ForceMode.Impulse);

        pushForce = 10f;
        power.text = string.Empty;
        barras = 0;
    }

    void BallPower()
    {
        if (Input.GetKey(KeyCode.E) && ball.transform.parent == playerCamera.transform) 
        {
            if (barras < 5)
            {
                tiempoTranscurrido += Time.deltaTime;
                if (tiempoTranscurrido >= 1f)
                {
                    barras += 1; 
                    power.text += "|";  
                    pushForce += 2f; 
                    tiempoTranscurrido = 0f;  
                }
            }
        }
    }

    void FallingBallReset()
    {
        if (ball.transform.position.y < -0.8f)
        {
            ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
            ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            ball.transform.position = ballInitialPosition; 
            ball.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
