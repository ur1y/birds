using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float VelocityToDestroy;
    public float ExplosionRadius; // =5 units, 1unit = 1grid-tile in Unity

    private void OnCollisionEnter2D(Collision2D collision) // При столкновении
    {
        if (collision.relativeVelocity.magnitude > VelocityToDestroy ) // Если скорость > заданного параметра
        {
            // GetComponent<CircleCollider2D>().radius // увеличение радиуса некоего коллайдера - как я себе представлял реализацию взрыва
            
            foreach (var collider in Physics2D.OverlapCircleAll(transform.position, ExplosionRadius))
            {
                if(collider.attachedRigidbody.bodyType == RigidbodyType2D.Dynamic) // проверка что выделенные коллайдер имеет динамический ригидбоди - это нужно чтобы не уничтожать объект "землю"
                {
                    Destroy(collider.gameObject);
                }
                

            }
            
            // Physics2D.OverlapCircleAll(transform.position, ExplosionRadius); // Выбрать все объекты в радиусе
            
            
            Destroy(gameObject); // убрать объект
        }
    }
}
