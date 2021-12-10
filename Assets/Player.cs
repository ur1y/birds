using UnityEngine;

public class Player : MonoBehaviour
{
    public bool IsFlying; // переменная для обозначения статуса персонажа = в полете / не в полете

    public Camera GameCamera;
    public float Power; // переменная мощность
    public float PowerModifier; // переменная модификатора мощность
    public bool IsGoingUp; // переменная да/нет
    public GameObject Arrow; // добавление игрового объекта - стрелочка
    public float PlayerTimeAlive; // сколько времени живет герой

    private void Start()
    {
    }

// апдейт   
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // если нажата мышь
        {
            if (IsFlying == false) // если статус персонажа = не в полете
            {
                var directionToMouse = GetNormalizedDirectionToMouse();

                GetComponent<Rigidbody2D>()
                    .AddForce(directionToMouse * Power * PowerModifier); // добавить воздействие силы на объект
                Arrow.SetActive(false); // отключить стрелочку
                IsFlying = true; // сказать что статус персонажа = в полете
            }
        }

        // условие уничтожить героя  
        if (IsFlying)
        {
            PlayerTimeAlive = PlayerTimeAlive - Time.deltaTime;
            if (PlayerTimeAlive < 0)
            {
                Destroy(gameObject);
            }
        }

        // увеличение или уменьшение стрелки
        if (IsGoingUp) // если нужно увеличивать мощность
        {
            Power = Power + Time.deltaTime; // увеличивать мощность
            if (Power > 2) // если достигнут предел увеличения мощности
            {
                IsGoingUp = false; // перестать увеличивать мощность
            }
        }
        else
        {
            Power = Power - Time.deltaTime; // уменьшать мощность
            if (Power < 1) // если достигнут предел уменьшения мощности
            {
                IsGoingUp = true; // нужно увеличивать мощность
            }
        }
        Arrow.transform.localScale = new Vector3(Power, Power, Power); // менять масштаб стрелки

        // Debug.Log("PlayerPosition = " + PlayerPosition); // показать координаты в лог
        var normDirectionToMouse = GetNormalizedDirectionToMouse();

        var angleToMouse = Vector3.SignedAngle(normDirectionToMouse, Vector3.up, Vector3.up);
        var arrowRotation = Arrow.transform.rotation.eulerAngles;
        Arrow.transform.rotation = Quaternion.Euler(arrowRotation.x, arrowRotation.y, -angleToMouse);
    }

    private Vector3 GetNormalizedDirectionToMouse()
    {
        var playerPosition = gameObject.transform.position; // координаты объекта Player
        var mousePosition = Input.mousePosition; // координаты мыши
        var worldMousePosition = GameCamera.ScreenToWorldPoint(
            new Vector3(mousePosition.x, mousePosition.y, -GameCamera.transform.position.z)
        );

        var directionToMouse = worldMousePosition - playerPosition;
        var normDirectionToMouse = directionToMouse.normalized;
        return normDirectionToMouse;
    }
}
