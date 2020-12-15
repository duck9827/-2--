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
            var timeSpan = new TimeSpan(0, 0, 0, 0, (int)(Timer.Instance.CurrentTime*1000));
            _text.text = $"{timeSpan.Minutes:00}:{timeSpan.Seconds:00}.{timeSpan.Milliseconds:000}"; 
        }
    }  
}

