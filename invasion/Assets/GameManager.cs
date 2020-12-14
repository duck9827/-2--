using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singletorn<GameManager>
{
    [SerializeField] GameObject overpanel;
    [SerializeField] GameObject menupanel;


    void Start()
    {
        
    }

  
    void Update()
    {


    }

    public void GameOver()
    {
        overpanel.SetActive(true);
        BossController.Instance.Over();
        Destroy(GameObject.Find("Player"));
    }


    public void GameReset()
    {
        menupanel.SetActive(false);
        overpanel.SetActive(false);
        UnityEngine.SceneManagement.SceneManager.LoadScene(gameObject.scene.name);
    }

}
