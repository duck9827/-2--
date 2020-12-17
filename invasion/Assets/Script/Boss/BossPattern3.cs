using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BossPattern3 : Singletorn<BossPattern3>
{
    public static bool topview = false; 
    
    [Range(0,360)]
    public float rotation = 0f;

    [Range(3,7)]
    public int Vertex = 4;

    [Range(1,5)]
    public float sup =3;
    public float speed=3;

     int m;
    float a;
    float phi;
    List<float> v = new List<float>();
    List<float> xx = new List<float>();

    public void init(){
         v.Clear();
        xx.Clear();
        m = (int)Mathf.Floor(sup / 2);
        a = 2 * Mathf.Sin(Mathf.PI / Vertex);
        phi = ((Mathf.PI / 2f) * (Vertex - 2f)) / Vertex;
        v.Add(0);
        xx.Add(0);

        for (int i = 1; i <= m; i++)
        {
            
            v.Add(Mathf.Sqrt(sup * sup - 2 * a * Mathf.Cos(phi) * i * sup + a * a * i * i));
        }

        for (int i = 1; i <= m; i++)
        {
            xx.Add(Mathf.Rad2Deg * (Mathf.Asin(a * Mathf.Sin(phi) * i / v[i])));
        }
        
    }
    public GameObject bullet;//임시
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

        if (active == false)     //만약 보스 패턴이 시작되거나 끝나지 않았을경우 3인칭뷰로 전환합니다.
        {
            topview = false;
        }

    }

    public void StartPattern()
    {
        active = true;
        d = transform.position + new Vector3(patroll * -0.5f, 0, 0);
        init();
        StartCoroutine("shapeAttack", 3);
        StartCoroutine("triattack", 5);
        StartCoroutine("moving");
    }
    public void StopPattern()
    {
        active = false;
        StopCoroutine("shapeAttack");
        StopCoroutine("triattack");
        StopCoroutine("moving");
    }

    IEnumerator shapeAttack()
    {
        var dir =rotation;
        
        while(active){
            for(int r=0;r<Vertex;r++){
                for(int i =1;i<=m;i++){

                    float vvvv= v[i]*speed/sup;
                    GameObject o1 = ObjectPoolManager.Instance.Spawn("enB",transform.position,Quaternion.identity);
                    o1.transform.rotation = Quaternion.Euler(0,  dir + xx[i],0);
                    o1.GetComponent<Rigidbody>().AddForce(o1.transform.forward*vvvv);
                    

                    
                    
                    GameObject o2 = ObjectPoolManager.Instance.Spawn("enB",transform.position,Quaternion.identity);
                    o2.transform.rotation = Quaternion.Euler(0, dir - xx[i],0);
                    o2.GetComponent<Rigidbody>().AddForce(o2.transform.forward*vvvv);
                    

                    vvvv= speed;
                    GameObject o3 = ObjectPoolManager.Instance.Spawn("enB",transform.position,Quaternion.identity);
                    o3.transform.rotation = Quaternion.Euler(0, dir,0);
                    o3.GetComponent<Rigidbody>().AddForce(o3.transform.forward*vvvv);
                    dir += 360/Vertex;

                }
            }
            dir=0;
            yield return new WaitForSeconds(2f);
            

        }
        

    }
    IEnumerator triattack()
    {
        while (active)
        {
            for (int i = 1; i < 6; i++)
            {
                for (int j = -2; j < 3; j++) {
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
            yield return new WaitForSeconds(5f);
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
