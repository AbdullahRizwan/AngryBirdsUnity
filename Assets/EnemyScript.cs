using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    int health = 5;
    public GameObject killingEffect;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.relativeVelocity.magnitude > health)
        {
            Die();
        }
    }

    private void Die()
    {
        killingEffect.transform.position = transform.position;
        killingEffect.SetActive(true);
        Instantiate(killingEffect,transform.position,Quaternion.identity);
        Destroy(this.gameObject); 
    }
}
