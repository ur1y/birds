using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float VelocityToDestroy;
    // public GameObject WinPanel; // игровой объект Окно Победы

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log(collision.relativeVelocity.magnitude);

        if (collision.relativeVelocity.magnitude > VelocityToDestroy )
        {
            Destroy(gameObject);
           //  WinPanel.SetActive(true); // показать Окно Победы
        }
    }
}