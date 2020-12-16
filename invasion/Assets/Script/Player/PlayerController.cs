using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float speed = 5f;
    
    private NavMeshAgent _agent; //스테이지 네비게이션 bake 필요
    
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        var dir = (cam.transform.forward *
            Input.GetAxis("Vertical") + cam.transform.right * Input.GetAxis("Horizontal")).normalized;
        
        _agent.Move(new Vector3(dir.x, 0, dir.z) * Time.deltaTime * speed);

        //보는 방향으로 플레이어 회전
        if (dir.magnitude > 0)
            transform.rotation = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.z));
        
        if (Input.GetKeyDown(KeyCode.Z)) //z키를 누를시 공격 
        {
            StartCoroutine("Shot");
        }
        if (Input.GetKeyUp(KeyCode.Z)) //z키를 누를시 공격 
        {
            StopCoroutine("Shot");
        }

        if (Input.GetKeyDown(KeyCode.Space)) //스페이스바를 누를 시 무적
        {
            PlayerStatus.noDamage = true;     //무적상태로 변경
        }

    }

    IEnumerator Shot()
    {
        while (true)
        {
            GameObject o = ObjectPoolManager.Instance.Spawn("myB", transform.position, transform.rotation);
            o.GetComponent<Rigidbody>().AddForce(transform.forward * 6);

            yield return new WaitForSeconds(0.2f);
        }
    }
}