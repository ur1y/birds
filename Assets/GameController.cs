using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject WinPanel; // игровой объект Окно Победы
    public GameObject LossPanel; // игровой объект Окно Поражения
    public GameObject Enemy; // игровой объект Враг
    public GameObject Player; // игровой объект Герой




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Enemy == null)
        {
            WinPanel.SetActive(true); // показать Окно Победы
        }

        if(Enemy == true && Player == null)
        {
        //    LossPanel.SetActive(true); // показать Окно Поражения
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
