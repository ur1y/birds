using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plank : MonoBehaviour
{
    public float VelocityToDestroy;
    private void OnCollisionEnter2D(Collision2D collision) // При столкновении
    {
        if (collision.relativeVelocity.magnitude > VelocityToDestroy ) // Если скорость > заданного параметра
        {
            Destroy(gameObject); // убрать объект
        }
    }
}
