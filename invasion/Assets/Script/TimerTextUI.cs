using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Timer
{
    public class TimerTextUI : MonoBehaviour
    {
        private Text _text;
        
        private void Awake()
        {
            _text = GetComponent<Text>();
        }

        void Update()
        {
            
            _text.text = Timer.Instance.GetTimeText(); 
        }
    }  
}

