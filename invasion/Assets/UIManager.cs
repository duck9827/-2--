using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singletorn<UIManager>
{
    [SerializeField] private Slider slider;
    [SerializeField] private BossStatus bossStatus;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = bossStatus.percent;
    }


    
}
