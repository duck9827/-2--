using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class CoolTimeUI : MonoBehaviour
{
    public static float cooltime = 10.0f;     //무적상태 쿨타임을 PlayerController 스크립트에서 처리 / 쿨타임 15초
    public Image img_Skill;
    private bool check;      //쿨타임 UI표시 체크 변수(false시에만 쿨타임 재생 / 초기값은 false)

    void Update () {
        if (Input.GetKeyDown((KeyCode.Space)))  //코루틴이 실행되지 않던 동안에만 이게 실행되게 해야...? 
        {
            if (check == false)
            {
                StartCoroutine(CoolTime (cooltime));
            }
        }
    }
    
    IEnumerator CoolTime (float cool)
    {
        check = true;
        while (cool > 1.0f)
        {
            cool -= Time.deltaTime;
            img_Skill.fillAmount = (1.0f / cool);
            yield return new WaitForFixedUpdate();
        }
        check = false;
    }
}