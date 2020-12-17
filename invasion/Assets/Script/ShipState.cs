using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipState : MonoBehaviour
{
    private Rigidbody rigid;
    private Transform player;
    [SerializeField] float lerpv;
    [SerializeField] float speed;
    [SerializeField] float MaxAngle;
    [SerializeField] GameObject ef;


    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        Vector3 dest = player.position - transform.position;
        Vector3 front = transform.forward;

        Vector3 dir = Vector3.Lerp(front, dest, lerpv);
        float angle = Vector3.Angle(front, dest);

        if (angle < MaxAngle)
        {
            rigid.velocity = dir.normalized * speed;
            transform.LookAt(transform.position + dir);
        }
    }


    private void OnEnable()
    {
        rigid.velocity = Vector3.zero;
    }

    private void OnDisable()
    {
        Instantiate(ef, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("bullet1")) 
        {
            other.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Stage")
        {
            gameObject.SetActive(false);
        }
    }
}
