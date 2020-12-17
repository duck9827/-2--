using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera ThirdPersonCamera;
    public Camera TopViewCamera;
    //private BossPattern2 call = GameObject.Find("Top View Camera").GetComponent < Update > ();
    
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
        if (BossPattern1.thirdview == true)     //패턴1: 3인칭뷰로 전환
        { 
            ThirdPersonView();
        }
        else if (BossPattern2.topview == true)     //패턴2: top뷰로 전환
        {
            TopView();
        }
        else if (BossPattern4.thirdview == true)     //패턴4: 3인칭뷰로 전환
        {
            ThirdPersonView();
        }
    }
}
