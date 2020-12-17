using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletState : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        transform.localScale = Vector3.one * 0.7f;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<MeshRenderer>().material.color = Color.white;
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.name == "Stage")
        {
            gameObject.SetActive(false);
        }
    }
}
