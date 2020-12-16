using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class CoolTimeUI : MonoBehaviour {
 
    public Image img_Skill;
    
    void Start () {
        
    }
    
    void Update () {
        if (Input.GetKeyDown (KeyCode.Space))
        {
            StartCoroutine(CoolTime (15.0f));
        }
    }
 
    IEnumerator CoolTime (float cool)
    {
        while (cool > 1.0f)
        {
            cool -= Time.deltaTime;
            img_Skill.fillAmount = (1.0f / cool);
            yield return new WaitForFixedUpdate();
        }
    }
}