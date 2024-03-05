using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActCommands : MonoBehaviour
{

    public void Exit()
    {
        Application.Quit();
    }

    private float speedLimit = 90;
    
    private float horizontalInput;

    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
        horizontalInput = Input.GetAxis("Horizontal");
    }
    private void FixedUpdate()


    {
        Exit();
        



        

        if (Input.GetKey(KeyCode.W))
        {
            _animator.SetBool("isRunning", true);
            transform.Translate(new Vector3(0, 0, 13f) * Time.deltaTime);
            transform.Rotate(Vector3.up * speedLimit * Time.deltaTime * horizontalInput);
        }
        else
        {
            _animator.SetBool("isRunning", false);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            _animator.SetBool("isJumping", true);
            transform.Translate(new Vector3(0, 0, 13f) * Time.deltaTime);
            transform.Rotate(Vector3.up * speedLimit * Time.deltaTime * horizontalInput);
        }
        else
        {
            _animator.SetBool("isJumping", false);
        }
    }
}
