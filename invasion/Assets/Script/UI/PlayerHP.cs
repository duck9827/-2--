using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class PlayerHP : MonoBehaviour
{
    [SerializeField]
    private Slider hpValue;
    [SerializeField]
    private PlayerStatus playerStatus;
    //[SerializeField] private float Hp;
  
 
    private void Update()
    {
        hpValue.value = playerStatus.percent;
        //hpValue.value = Mathf.Lerp(hpValue.value, Hp, Time.deltaTime * 10);    // 체력 감소 선형보간
    }
 
}