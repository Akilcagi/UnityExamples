using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 200f;
    private float currentHealth;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0f)
        {
            Die();
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Castle"))
        {
            other.gameObject.GetComponent<CastleHealth>().TakeDamage(10); 
            Destroy(gameObject); 
        }
    }


    void Die()
    {
        
        if (GameManager.instance != null)
        {
            GameManager.instance.AddResources(25); 
        }
        GameManager.instance.EnemyKilled();

        Debug.Log(gameObject.name + " destroyed.");
        Destroy(gameObject);
    }
}
