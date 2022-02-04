using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class WinPanel : MonoBehaviour
{
    public GameProgress Progress;
    

    private void Start()
    {
        Progress = FindObjectOfType<GameProgress>(); // находим скрипт GameProgress который должен быть в сцене 
    }

    
    public void PlayNextLevel() // Следующий уровень
    {
        // Debug.Log("Button was pressed");
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex; // перменная которая получает значение активной сцены
        if (currentSceneIndex == SceneManager.sceneCountInBuildSettings - 1) // является ли загруженная сцена последней
        {
            ChangeLevelTo(1);
//            SceneManager.LoadScene(1); // если да, то грузим первый уровень
            Progress.SetCurrentLevel(1); // переддаем значение методу
        }
        else
        {
            ChangeLevelTo(currentSceneIndex + 1);
//           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // если нет, то грузим следующий уровень
            Progress.SetCurrentLevel(currentSceneIndex + 1); // переддаем значение методу
        }
    }   

    public void ChangeLevelTo(int level) // функция которая переключает уровень
    {
        SceneManager.LoadScene(level);
        Progress.SetCurrentLevel(level);

        gameObject.SetActive(false); // деактивирует WinPanel
    }
}
