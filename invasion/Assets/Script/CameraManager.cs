using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera ThirdPersonCamera;
    public Camera TopViewCamera;

    private void Start()     //시작할땐 3인칭 카메라를 켜둡니다. 
    {
        ThirdPersonView();
    }

    public void TopView()     //시점을 탑뷰로 전환
    {
        TopViewCamera.enabled = true;
        ThirdPersonCamera.enabled = false;
    }

    public void ThirdPersonView()     //시점을 3인칭으로 변환
    {
        TopViewCamera.enabled = false;
        ThirdPersonCamera.enabled = true;
    }

    private void Update()
    {
        if (BossPattern2.topview == true)     //top뷰로 전환
        {
            TopView();
        }
        if (BossPattern2.topview == false)     //3인칭뷰로 전환
        {
            ThirdPersonView();
        }
    }
    //private void Update()
    //{
        //if (Input.GetKey("1"))     //1번키를 누르면 탑뷰로 전환
        //{
            //TopView();
        //}

        //if (Input.GetKey("2"))     //2번키를 누르면 3인칭 뷰로 전환 
        //{
            //ThirdPersonView();
        //}
    //}
}
