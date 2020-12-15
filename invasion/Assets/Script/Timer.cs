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
        public float CurrentTime => _time;

        void Start()
        {

        }



        void Update()
        {
            _time += Time.deltaTime;
            

            
        }
    }
}
    
