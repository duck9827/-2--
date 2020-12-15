using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPattern4 : Singletorn<BossPattern4>
{

    //[SerializeField] float patroll = 10f;
    //[SerializeField] float patrollDelay = 5f;
    private bool active = false;

    private void Update()
    {

    }

    public void StartPattern()
    {
        active = true;
        StartCoroutine("circleattack", 3);
        StartCoroutine("triattack", 5);
    }
    public void StopPattern()
    {
        active = false;
        StopCoroutine("circleattack");
        StopCoroutine("triattack");
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
            yield return new WaitForSeconds(3f);
        }
    }
    IEnumerator triattack()
    {
        while (active)
        {
            for (int j = -1; j < 2; j++)
            {
                Quaternion q = Quaternion.Euler(0, j * 30, 0);

                GameObject o = ObjectPoolManager.Instance.Spawn("ship", transform.position, q);
                
            }
            yield return new WaitForSeconds(5f);
        }
    }

}
