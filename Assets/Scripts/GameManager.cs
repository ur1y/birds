using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public WinPanel winPanel;
 //   public Button restartButton;
    
    private void Start()
    {
        DontDestroyOnLoad(gameObject); // не разрушаем после загрузки


 //       restartButton.onClick.AddListener(LevelRetart);
    }
/*
    private void LevelRestart()
    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
*/



//  с кнопками можно работать несколькими способами, самый надежный - повесить на кнопку "слушателей"
/*
    private vode OnEnable()
    {
        restartButton.onClick.AddListener(LevelRetart);
    }

    private void OnDisable()
    {
        throw new NotImplementedException();
    }
*/


    public WinPanel GetWinPanel()
    {
        return winPanel;
    }
    
    void Update()
    {
        
    }
}
