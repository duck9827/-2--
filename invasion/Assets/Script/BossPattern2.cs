using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPattern2 : Singletorn<BossPattern2>
{
    public GameObject bullet;//임시
    
    private float time = 0;
    private bool active = false;


    public void StartPattern()
    {
        active = true;
        StartCoroutine("circleatack", 3);
    }
    public void StopPattern()
    {
        active = false;
    }

    IEnumerator circleatack()
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
            yield return new WaitForSeconds(0.5f);
        }
    }

}
