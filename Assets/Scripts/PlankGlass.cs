using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlankGlass : MonoBehaviour
{
    public float VelocityToDestroy;
    private void OnCollisionEnter2D(Collision2D collision) // При столкновении
    {
        if (collision.relativeVelocity.magnitude > VelocityToDestroy ) // Если скорость > заданного параметра
        {
            Destroy(gameObject); // убрать объект
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        var player = col.gameObject.GetComponent<Player>();
        if (player != null && player.IsGlass)
        {
            Destroy(gameObject);
        }
    }
}
