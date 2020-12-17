using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class DataList
{
    public List<float> list;
}

public class GameManager : Singletorn<GameManager>
{
    [SerializeField] GameObject overpanel;
    [SerializeField] GameObject menupanel;
    [SerializeField] GameObject scoreUI;
    private DataList cleardata;

    void Start()
    {
        Timer.Timer.Instance.TimerStart();


        var path = Path.Combine(Application.persistentDataPath, "Savedata.json");
        if (File.Exists(path))
        {
            var data = JsonUtility.FromJson<DataList>(File.ReadAllText(path));
            cleardata = data;
        }
        else
            cleardata = new DataList();
        
    }

  
    void Update()
    {

    }

    private void SetScore()
    {
        overpanel.transform.Find("NowScoreUI").GetComponentInChildren<Text>().text = "현재: " + Timer.Timer.Instance.GetTimeText();

        for (int i=0; i<5; i++)
        {
            if (i >= cleardata.list.Count)
                break;

            var timeSpan = new TimeSpan(0, 0, 0, 0, (int)(cleardata.list[i] * 1000));
            var text = $"{timeSpan.Minutes:00}:{timeSpan.Seconds:00}.{timeSpan.Milliseconds:000}";

            var o = Instantiate(scoreUI, overpanel.transform);
            o.transform.localPosition = new Vector3(0,40 - (i*30),0);
            o.GetComponentInChildren<Text>().text = (i+1)+"위: " +text;
        }
    }

    public void Win()
    {
        Timer.Timer.Instance.TimerStop();
        overpanel.SetActive(true);
        overpanel.GetComponentInChildren<Text>().text = "CLEAR!";

        //저장
        cleardata.list.Add(Timer.Timer.Instance.CurrentTime);
        cleardata.list.Sort();
        var jsonText = JsonUtility.ToJson(cleardata);
        File.WriteAllText(Path.Combine(Application.persistentDataPath, "Savedata.json"), jsonText,Encoding.UTF8);
        //
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
