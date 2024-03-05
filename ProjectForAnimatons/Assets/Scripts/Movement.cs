using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float speedLimit = 40f;
    private float Speed = 25f;
    private float horizontalInput;
    private float forwardInput;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Speed * Time.deltaTime * forwardInput);
        transform.Rotate(Vector3.up * speedLimit * Time.deltaTime * horizontalInput);
    }
}
