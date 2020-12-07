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
        PlayerStatus.Instance.Init();
        BossController.Instance.Init();
    }

}
