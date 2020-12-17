using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BossPattern1 : Singletorn<BossPattern3>
{
    public static bool thirdview = false; 
    
    [Range(0,360)]
    public float rotation = 0f;


    [Range(1,5)]
    public float sup =3;
    public float speed=3;

     int m;
    float a;
    float phi;
    List<float> v = new List<float>();
    List<float> xx = new List<float>();

   

    private bool active = false;
    private Vector3 d;
    private void Update()
    {
         if (active)
        {
            transform.position = Vector3.Lerp(transform.position, d, 0.005f);
            thirdview = true;

        }
         else
         {
             thirdview = false;
         }
    }

    public void StartPattern()
    {
        active = true;
        
        StartCoroutine("shapeAttack", 3);
    }
    public void StopPattern()
    {
        active = false;
        StopCoroutine("shapeAttack");
    }

    IEnumerator shapeAttack()
    {
        var dir =rotation;
        
        while(active){
            for(int r=0;r<4;r++){
                
                    
                    GameObject o1 = ObjectPoolManager.Instance.Spawn("enB",transform.position,Quaternion.identity);
                    o1.transform.rotation = Quaternion.Euler(0, dir,0);
                    o1.GetComponent<Rigidbody>().AddForce(o1.transform.forward*5f);
                    

                    
                    
                    GameObject o2 = ObjectPoolManager.Instance.Spawn("enB",transform.position,Quaternion.identity);
                    o2.transform.rotation = Quaternion.Euler(0, dir+90,0);
                    o2.GetComponent<Rigidbody>().AddForce(o2.transform.forward*5f);
                    

                    
                    GameObject o3 = ObjectPoolManager.Instance.Spawn("enB",transform.position,Quaternion.identity);
                    o3.transform.rotation = Quaternion.Euler(0, dir+180,0);
                    o3.GetComponent<Rigidbody>().AddForce(o3.transform.forward*5f);

                    GameObject o4 = ObjectPoolManager.Instance.Spawn("enB",transform.position,Quaternion.identity);
                    o4.transform.rotation = Quaternion.Euler(0, dir+240,0);
                    o4.GetComponent<Rigidbody>().AddForce(o3.transform.forward*5f);
                    dir += 1;

                
            }
            yield return new WaitForSeconds(0.2f);
            

        }
        

    }
  
    
}
