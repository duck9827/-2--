using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP_Zero : MonoBehaviour //슬라이더바의 체력이 o이하가 될시, Fill을 비활성화 시켜 체력바가 비도록. 
{
    private Slider slHP;

    private float fSliderBarTime;
    
    // Start is called before the first frame update
    void Start()
    {
        slHP = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (slHP.value <= 0)
            transform.Find("Fill Area").gameObject.SetActive(false);
        else
        {
            transform.Find("Fill Area").gameObject.SetActive(true);
        }
    }
}
