using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 startPosition;
    public float moveSpeed = 17f;

    
    public float minX = -40f;
    public float maxX = 30f;
    public float minZ = -80f;
    public float maxZ = 70f;
    public float boundary = 50f;
    public float zoomSpeed = 5f;
    public float minY = 10f; 
    public float maxY = 80f;

    void Start()
    {
        startPosition = transform.position; 
    }

    void Update()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey("w"))
        {
            pos += transform.forward * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            pos -= transform.forward * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            pos += transform.right * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            pos -= transform.right * moveSpeed * Time.deltaTime;
        }
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.y -= scroll * zoomSpeed * 100f * Time.deltaTime; 


       
        pos.x = Mathf.Clamp(pos.x, startPosition.x + minX, startPosition.x + maxX);
        pos.y = Mathf.Clamp(pos.y, startPosition.y + minY, startPosition.y + maxY);
        pos.z = Mathf.Clamp(pos.z, startPosition.z + minZ, startPosition.z + maxZ);

        

        transform.position = pos;

    }
}
