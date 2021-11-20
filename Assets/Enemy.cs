using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float VelocityToDestroy;
    // public GameObject WinPanel; // игровой объект Окно Победы

    void Start()
    {
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log(collision.relativeVelocity.magnitude);

        if (collision.relativeVelocity.magnitude > VelocityToDestroy )
        {
            Destroy(gameObject);
            // GameController.EnemyCount = GameController.EnemyCount - 1;
           //  WinPanel.SetActive(true); // показать Окно Победы
        }
    }
}