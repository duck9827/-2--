using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//임시 스크립트
public class PlayerController : MonoBehaviour
{
    public float playerspeed = 1;


    void Start()
    {
        
    }

    void Update()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));

        transform.position += direction * playerspeed * Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            GameObject o = ObjectPoolManager.Instance.Spawn("myB", transform.position, transform.rotation);
            o.GetComponent<Rigidbody>().AddForce(transform.forward * 5);
        }
    }
}
