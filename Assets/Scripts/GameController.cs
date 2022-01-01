using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject WinPanel; // игровой объект Окно Победы
    public GameObject LossPanel; // игровой объект Окно Поражения
    public GameObject[] Enemies; // игровой объект Враги // ........... ?????????????? что значат добавленные квадратные скобки ??????????????? .....................
    public GameObject Player; // игровой объект Герой

    private void Start()
    {
        // !!!!! 
        // 1-й способ проверки что все враги убиты:
        // 1). посчитать кол-во объектов с тэгом "Enemy", 
        // 2). при убийстве врага отнимать -1 из EnemyCount, 
        // 3). если EnemyCount == 0, то победа. 
        // Но я не смог разобраться как в Enemy.cs обращаться к EnemyCount и отнимать у него -1.

        Enemies =
            GameObject.FindGameObjectsWithTag("Enemy"); //  получить объекты с тэгом "Enemy"
    }

    // Update is called once per frame
    private void Update()
    {
// Проверка что все враги уничтожены
        var allEnemiesAreDead = true;
        foreach (var enemy in Enemies)
        {
            // выполнить для каждого врага
            if (enemy != null)
            {
                allEnemiesAreDead = false;
            }
        }

// Условие победы
        if (allEnemiesAreDead)
        {
            WinPanel.SetActive(true); // показать Окно Победы   
        }

// Условие поражения
        else if (Player == null)
        {
            Debug.Log("Player = null");
            LossPanel.SetActive(true); // показать Окно Поражения
        }

// Перезагрузка сцены
        if (WinPanel == true) // зачем?
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // перезагружаем эту же сцену
            }
        }




    }
}
