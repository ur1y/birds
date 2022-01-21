using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameProgress : MonoBehaviour
{
    public const string CurrentLevelKey = "current.level"; // ?

    private void Start()
    {
        
        

        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex; // создаем переменную которая получает номер текущей загруженной сцены
        var currentLevel = GetCurrentLevel(); // создаем переменную которая получает номер уровня по прогрессу

        if (currentLevel != currentSceneIndex) // если уровень по прогрессу не равен загруженному уровню
        {
            SceneManager.LoadScene(currentLevel); // загрузить уровень по номеру прогресса
        }
    }


    public void SetCurrentLevel(int Value)
    {
        Debug.Log("Set current level: " + Value);
        PlayerPrefs.SetInt(CurrentLevelKey, Value); // "запоминаем" какой сейчас уровень
    }

    public int GetCurrentLevel()
    {
        return PlayerPrefs.GetInt(CurrentLevelKey, 1); // 1 - дефолтное значение сцены, если значение еще не присовено
    }
}
