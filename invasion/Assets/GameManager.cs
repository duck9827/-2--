using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singletorn<GameManager>
{
    
    void Start()
    {
        
    }

  
    void Update()
    {
        
    }

    public void GameReset()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(gameObject.scene.name);
    }

}
