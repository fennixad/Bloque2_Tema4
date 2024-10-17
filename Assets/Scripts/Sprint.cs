using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class Sprint : MonoBehaviour
{
    float timer = 0;
    float playerVelocity;
    float extraVelocity = 2f;
    ThirdPersonController thirdPersonController;
    public GameObject spherePrefab;
    public Transform spawnPoint;

    void Start()
    {
        thirdPersonController = GameObject.FindGameObjectWithTag("Player").GetComponent<ThirdPersonController>();
        playerVelocity = thirdPersonController.MoveSpeed;
        Debug.Log(playerVelocity);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer == 0)
            {
                Instantiate(spherePrefab, spawnPoint.position, spawnPoint.rotation);
            }
        } 
        else
        {
            thirdPersonController.MoveSpeed = playerVelocity;           
        }

    }

    void OnTriggerEnter(Collider collider)
    {
        thirdPersonController.MoveSpeed += extraVelocity;
        timer = 3;
        Destroy(this.gameObject);
    }


}
