using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
     Vector2 startPois;
    
    private void Start()
    {
        startPois = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("KillBox"))
        {
            Die();
        }

    }
    void Die()
    {
        Respawn();
    }

     void Respawn()
    {
        transform.position = startPois;
    }

}
