using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 Force; // координаты направления в котором будет летететь "герой"
    public bool IsFlying; // переменная для обозначения статуса персонажа = в полете / не в полете

    public float Power; // переменная мощность
    public bool IsGoingUp; // переменная да/нет
    public GameObject Arrow; // добавление игрового объекта - стрелочка
    public float PlayerTimeAlive; // сколько времени живет герой
    
    
    
    void Start()
    {
        
    }

// апдейт   
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) // если нажата мышь
        {
            if(IsFlying == false) // если статус персонажа = не в полете
            {
                var TouchPosition = Input.mousePosition; // переменная получает координаты точки курсора мыши в момент нажатия
                Debug.Log("TouchPosition = " + TouchPosition); // показать координаты в лог

                GetComponent<Rigidbody2D>().AddForce(TouchPosition * Power); // добавить воздействие силы на объект
                Arrow.SetActive(false); // отключить стрелочку
                IsFlying = true; // сказать что статус персонажа = в полете
            } 
        }

     // условие уничтожить героя  
        if(IsFlying == true)
        {
            PlayerTimeAlive = PlayerTimeAlive - Time.deltaTime;
            if(PlayerTimeAlive < 0)
            {
                Destroy(gameObject);
            }

        }

    // увеличение или уменьшение стрелки
        if(IsGoingUp) // если нужно увеличивать мощность
        {
            Power = Power + Time.deltaTime; // увеличивать мощность
            if(Power > 2) // если достигнут предел увеличения мощности
            {
                IsGoingUp = false; // перестать увеличивать мощность
            }
        }
        else
        {
            Power = Power - Time.deltaTime; // уменьшать мощность
            if(Power < 1) // если достигнут предел уменьшения мощности
            {
                IsGoingUp = true; // нужно увеличивать мощность
            }
        }
        Arrow.transform.localScale = new Vector3(Power, Power, Power); // менять масштаб стрелки
        
   
//    
        var PlayerPosition = gameObject.transform.position; // координаты объекта Player
        // Debug.Log("PlayerPosition = " + PlayerPosition); // показать координаты в лог
        var MovePosition = Input.mousePosition; // координаты мыши
        
        // if(Input.GetAxis("Mouse X")<0) // если движется мышь
        // {
            // MovePosition = Input.mousePosition; // взять координаты мыши
            // Debug.Log("MovePosition = " + MovePosition); // показать координаты в лог
            float ArrowDirectionAngle = Vector3.Angle(PlayerPosition, Input.mousePosition); // угол между объектом Player и указателем мыши - считает НЕ правильно, что-то сделано НЕ правильно.
            Debug.Log("ArrowDirectionAngle = " + ArrowDirectionAngle);

            // Arrow.transform.eulerAngles  = new Vector3(0f ,0f, ArrowDirectionAngle); // менять угол стрелки, НЕ правильно
        // }
    
        


       
 
    }
}
