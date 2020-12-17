using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BossPattern2 : Singletorn<BossPattern2>
{
    public static bool topview = false;     //보스패턴 시작시 true로 전환 (탑뷰 카메라 전환을 위함)
    
    [SerializeField] float patroll = 10f;
    [SerializeField] float patrollDelay = 5f;
    private bool active = false;
    private Vector3 d;


    private void Update()
    {
        if (active)
        {
            transform.position = Vector3.Lerp(transform.position, d, 0.005f);
            topview = true;     //카메라가 탑뷰로 전환됨 (CameraManager스크립트에서 처리)
        }

        else
        {
            topview = false;
        }
    }

    public void StartPattern()
    {
        active = true;
        d = transform.position + new Vector3(patroll * -0.5f, 0, 0);
        StartCoroutine("circleattack", 3);
        StartCoroutine("triattack", 5);
        StartCoroutine("moving");
    }
    public void StopPattern()
    {
        active = false;
        StopCoroutine("circleattack");
        StopCoroutine("triattack");
        StopCoroutine("moving");
    }

    IEnumerator circleattack()
    {
        int r = 0;
        while (active)
        { 
            for (int i = 0; i < 12; i++)
            {
                Vector3 p = new Vector3(Mathf.Sin((i * 30 + r) * 6.28f / 360), 0, Mathf.Cos((i * 30 + r) * 6.28f / 360));
                GameObject o = ObjectPoolManager.Instance.Spawn("enB", transform.position + p * 3, Quaternion.identity);
                o.GetComponent<Rigidbody>().AddForce(p * 5);
            }
            r += 5;
            yield return new WaitForSeconds(1f);
        }
    }
    IEnumerator triattack()
    {
        while (active)
        {
            for (int i = 1; i < 6; i++)
            {
                for (int j = -1; j < 2; j++) {
                    Vector3 p = (PlayerStatus.Instance.transform.position - transform.position);
                    p.y = 0;
                    p = Quaternion.AngleAxis(j * 15, Vector3.up) * p;
                    p = p.normalized;
                    

                    GameObject o = ObjectPoolManager.Instance.Spawn("enB", transform.position, Quaternion.identity);
                    o.GetComponent<Rigidbody>().AddForce(p * i);

                    o.GetComponent<MeshRenderer>().material.color = Color.yellow;
                    o.GetComponent<Transform>().localScale = new Vector3(0.22f, 0.24f, 0.57f); //노란색 총알의 사이즈 변경
                    
                }
            }
            yield return new WaitForSeconds(4f);
        }
    }
    IEnumerator moving()
    {
        bool t = true;
        while (active)
        {
            if (t)
                d += new Vector3(patroll, 0, 0);
            else
                d -= new Vector3(patroll, 0, 0);

            t = !t;

            yield return new WaitForSeconds(patrollDelay);
        }
    }
}
