using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoDamageTimeUI : MonoBehaviour
{
    private Slider skillTImer;
    void Start()
    {
        skillTImer = GetComponent<Slider>();
        skillTImer.value = PlayerController.skilltime + 1.5f;
    }
    
    void Update()
    {
        //print(skillTImer.value);
        if ((skillTImer.value >= 0.0f)&&(PlayerStatus.noDamage == true))
        {
            skillTImer.value -= Time.deltaTime;     //스킬시간만큼 슬라이더가 줄어듭니다. 
        }
        else if (PlayerStatus.noDamage == false)     //스킬을 다 쓰고 나면 다시 초기화 
        {
            skillTImer.value = PlayerController.skilltime = 1.5f;
        }
    }
}
