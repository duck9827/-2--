using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float speed = 5f;

    //private Rigidbody rigidbody;
    private NavMeshAgent _agent; //스테이지 네비게이션 bake 필요
    
    //public float jumpPower = 50f;
    
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    //void Start()
    //{
        // 힘을 가하기 위해 게임 오브젝트에 추가된 Rigidbody 컴포넌트의 인스턴스를 얻는다.
        //rigidbody = GetComponent<Rigidbody>();
    //}
    
    private void Update()
    {
        var dir = (cam.transform.forward *
            Input.GetAxis("Vertical") + cam.transform.right * Input.GetAxis("Horizontal")).normalized;
        
        _agent.Move(new Vector3(dir.x, 0, dir.z) * Time.deltaTime * speed);
        
        //보는 방향으로 플레이어 회전
        transform.rotation = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.z));
        
        if (Input.GetKeyDown(KeyCode.Z)) //z키를 누를시 공격 
        {
            GameObject o = ObjectPoolManager.Instance.Spawn("myB", transform.position, transform.rotation);
            o.GetComponent<Rigidbody>().AddForce(transform.forward * 5);
        }

        //if (Input.GetKeyDown(KeyCode.Space)) //스페이스바를 누를 시 점프
        //{
            //rigidbody.AddForce(Vector3.up * jumpPower , ForceMode.Impulse);
        //}

    }


}