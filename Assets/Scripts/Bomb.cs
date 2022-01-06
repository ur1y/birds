using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float VelocityToDestroy;
    public float ExplosionRadius; // =5 units, 1unit = 1grid-tile in Unity
    public float BombTimeAlive; // сколько времени живет бомба перед взрывом


    private void OnCollisionEnter2D(Collision2D collision) // При столкновении
    {
        {
            // Взрывание бомбы
            if (collision.relativeVelocity.magnitude > VelocityToDestroy ) // Если скорость > заданного параметра
            {
                // GetComponent<CircleCollider2D>().radius // увеличение радиуса некоего коллайдера - как я себе представлял реализацию взрыва
                BombTimeAlive = BombTimeAlive - Time.deltaTime;

                if (BombTimeAlive < 0)
                {
                    foreach (var collider in Physics2D.OverlapCircleAll(transform.position, ExplosionRadius))
                    {
                        if(collider.attachedRigidbody.bodyType == RigidbodyType2D.Dynamic) // проверка что выделенные коллайдер имеет динамический ригидбоди - это нужно чтобы не уничтожать объект "землю"
                        {
                            // Destroy(collider.gameObject); // уничтожить все объекты у которых есть выделенный коллайдер
                            
                            Vector2 dir = collider.transform.position - transform.position; // если из вектора одного объекта вычесть вектор другого объекта, то получится вектор-направление между двумя этими объектами (transform.position - координаты бомбы)
                            collider.attachedRigidbody.AddForce(dir.normalized * 500); // вектор нужно нормализовать чтобы объекты которые расположены дальше не имели большую силу за счет более длинного вектора
                        }
                        

                    }
                    
                    // Physics2D.OverlapCircleAll(transform.position, ExplosionRadius); // Выбрать все объекты в радиусе
                    
                    
                    Destroy(gameObject); // убрать объект
                }
            }
        }
    }
}
