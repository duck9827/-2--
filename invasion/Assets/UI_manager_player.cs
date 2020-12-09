using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_manager_player : Singletorn<UIManager>
{
    [SerializeField] private Slider slider;
    [SerializeField] private PlayerStatus playerStatus;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = playerStatus.HP / playerStatus.MaxHP;
        
    }


    
}