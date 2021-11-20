using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject WinPanel; // игровой объект Окно Победы
    public GameObject LossPanel; // игровой объект Окно Поражения
    public GameObject Enemy1; // игровой объект Враг1
    public GameObject Enemy2; // игровой объект Враг2
    public GameObject Player; // игровой объект Герой
    public int EnemyCount; // кол-во объектов Enemy


 
    void Start()
    {
    // !!!!! 
    // 1-й способ проверки что все враги убиты:
    // 1). посчитать кол-во объектов с тэгом "Enemy", 
    // 2). при убийстве врага отнимать -1 из EnemyCount, 
    // 3). если EnemyCount == 0, то победа. 
    // Но я не смог разобраться как в Enemy.cs обращаться к EnemyCount и отнимать у него -1.
    
    EnemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length; //  посчитать кол-во объектов с тэгом "Enemy", при убийстве врага отнимать 
    Debug.Log("EnemyCount = " + EnemyCount);
    }



    // Update is called once per frame
    void Update()
    {
        
        if((Enemy1 == null) && (Enemy2 == null))
        {
            WinPanel.SetActive(true); // показать Окно Победы
        }

        else if(Player == null)
        {
            Debug.Log("Player = null");
            LossPanel.SetActive(true); // показать Окно Поражения
        }

        if(WinPanel == true)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

    }
}
