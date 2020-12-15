using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singletorn<GameManager>
{
    [SerializeField] GameObject overpanel;
    [SerializeField] GameObject menupanel;

    private float[] scores;


    void Start()
    {
        
    }

  
    void Update()
    {


    }

    public void Win()
    {
        overpanel.GetComponentInChildren<Text>().text = "YOU WIN";
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

    public void GameExit()
    {
        Application.Quit();
    }
}
