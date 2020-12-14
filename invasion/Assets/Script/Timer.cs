using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Timer
{
    public class Timer : Singletorn<Timer>
    {
        public float LimitTime;
        
        private Text _text;

        void Start()
        {

        }

        private void Awake()
        {
            _text = GetComponent<Text>();
        }

        void Update()
        {
            LimitTime -= Time.deltaTime;
            
            var timeSpan = new TimeSpan(0, 0, (int)(Timer.Instance.LimitTime/60), (int)(Timer.Instance.LimitTime%60), 0);
            _text.text = $"{timeSpan.Minutes:00}:{timeSpan.Seconds:00}.{timeSpan.Milliseconds:000}"; 
            
            //timeSpan 부분에 (int)(Timer.Instance.LimitTime*1000) 부분 추가시 입력받은 초가 두배로 표시되는 오류(표시상 2초씩 줄어듭니다..) 발생. 방법 연구중입니다. 
        }
    }
}
    
