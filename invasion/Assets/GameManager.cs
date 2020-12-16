using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singletorn<GameManager>
{
    [SerializeField] GameObject overpanel;
    [SerializeField] GameObject menupanel;


    void Start()
    {
        Timer.Timer.Instance.TimerStart();
    }

  
    void Update()
    {

    }

    private void SetScore()
    {
        overpanel.transform.Find("NowScoreUI").GetComponentInChildren<Text>().text = "현재: " + Timer.Timer.Instance.GetTimeText();
    }

    public void Win()
    {
        Timer.Timer.Instance.TimerStop();
        overpanel.SetActive(true);
        overpanel.GetComponentInChildren<Text>().text = "CLEAR!";
        SetScore();
    }

    public void GameOver()
    {
        Timer.Timer.Instance.TimerStop();
        overpanel.SetActive(true);
        BossController.Instance.Over();
        Destroy(GameObject.Find("Player"));
        SetScore();
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
