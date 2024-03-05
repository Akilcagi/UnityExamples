using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Button buttoon;

    private Rigidbody _rigidbody;
    public float Speed = 100f;
    public Text Timee, Health, Action;
    float timmer = 600;
    float health = 15;
    bool isActive = true;
    bool finished = false;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (isActive)
        {
            timmer -= Time.deltaTime;
            Timee.text = (int)timmer + " ";

        }
        else if (!finished)
        {
            Action.text = "You Lost!";
            buttoon.gameObject.SetActive(true);
        }
        if (timmer < 0)
        {
            isActive = false;
        }


    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (isActive && !finished)

        {
            float horizontalValue = Input.GetAxis("Horizontal");
            float verticalValue = Input.GetAxis("Vertical");
            Vector3 strenght = new Vector3(horizontalValue, 0, verticalValue);
            _rigidbody.AddForce(strenght * Speed);


        }
        else
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
        }

    }
    private void OnCollisionEnter(Collision obstacle)
    {
        string arrived = obstacle.gameObject.name;
        if (arrived.Equals("FinishingPoint"))
        {
            finished = true;
            Action.text = "You Won! Congratulations";
            buttoon.gameObject.SetActive(true);

        }
        else if (!arrived.Equals("Plane") && !arrived.Equals("StartingPoint"))
        {
            health -= 1;
            Health.text = health + " ";
            if (health == 0)
            {
                isActive = false;
            }
        }
    }
}
