using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Timer
{
    public class Timer : Singletorn<Timer>
    {
        private float _time;
        private bool active;
        public float CurrentTime => _time;

        void Update()
        {
            if(active)
                _time += Time.deltaTime;
        }

        public void TimerStart()
        {
            active = true;
        }
        public void TimerStop()
        {
            active = false;
        }
        public void TimerReset()
        {
            active = false;
            _time = 0;
        }
    }
}
    
