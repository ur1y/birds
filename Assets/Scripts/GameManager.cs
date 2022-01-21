using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    private void Start()
    {
        DontDestroyOnLoad(gameObject); // не разрушаем после загрузки
    }

    
    void Update()
    {
        
    }
}
