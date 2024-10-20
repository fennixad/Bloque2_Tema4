using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public GameObject parent;
    private Transform dinamicCube;
    private Transform dinamicCyllinder;
    public float move_Speed = 3.0f;
    public float rotation_Speed = 5f;
    private float maxPositionX = 5.0f;
    private float minPositionX = -5.0f;
    bool moving = true;

    void Start()
    {
        dinamicCube = parent.transform.Find("DinamicCube");
        dinamicCyllinder = parent.transform.Find("DinamicCyllinder");
    }

    // Update is called once per frame
    void Update()
    {
        CubeMovementManager(dinamicCube);
        CyllinderMovementManager(dinamicCyllinder);
    }
    void CubeMovementManager(Transform obj)
    {
        if (moving)
        {
            obj.Translate(Vector3.left * move_Speed * Time.deltaTime);

            if (obj.position.x <= minPositionX)
            {
                moving = false;
            }
        }
        else
        {
            obj.Translate(Vector3.right * move_Speed * Time.deltaTime);

            if (obj.position.x >= maxPositionX)
            {
                moving = true;
            }
        }
    }
    void CyllinderMovementManager(Transform obj)
    {
        obj.Rotate(0, rotation_Speed * Time.deltaTime, 0);
    }
}
