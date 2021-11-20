using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plank : MonoBehaviour
{
    public float VelocityToDestroy;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > VelocityToDestroy )
        {
            Destroy(gameObject);
        }
    }
}
