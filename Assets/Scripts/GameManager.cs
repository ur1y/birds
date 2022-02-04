using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public WinPanel winPanel;
    public Button restartButton;
    
    private void Start()
    {
        DontDestroyOnLoad(gameObject); // не разрушаем после загрузки


        restartButton.onClick.AddListener(LevelRestart);
    }

    private void LevelRestart()
    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }




//  с кнопками можно работать несколькими способами, самый надежный - повесить на кнопку "слушателей"

    private void OnEnable()
    {
        restartButton.onClick.AddListener(LevelRestart);
    }

    private void OnDisable()
    {
 //       throw new NotImplementedException();
    }



    public WinPanel GetWinPanel()
    {
        return winPanel;
    }
    
    void Update()
    {
        
    }
}
