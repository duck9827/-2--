using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float speed = 5f;
    
    public static float skilltime = 3.0f;     //스킬 시간
    private float skill_timer; //스킬 지속여부 체크용 변수
    private bool check;      //스킬 쿨타임 여부 체크
    private bool skillCheck; //스킬사용여부 체크, false일땐 사용한 상태입니다. 
    private float timer; //쿨타임 여부 체크

    private NavMeshAgent _agent; //스테이지 네비게이션 bake 필요
    
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        print(skill_timer);
        //print(timer);
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
            if ((skillCheck == false)&&(timer <= 0.0f))
            {
                StartCoroutine("NoDamage");
                StartCoroutine("SkillCool");
            }
        }

    }

    private void Start()
    {
        skill_timer = skilltime;
        timer = 0.0f;
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
    
    IEnumerator NoDamage ()
    {
        skillCheck = true;
        while (skill_timer > 0)
        {
            PlayerStatus.noDamage = true;     //무적상태로 변경
            skill_timer -= Time.deltaTime;
            timer -= Time.deltaTime; 
            yield return new WaitForSeconds(0.0f);
        }
        skillCheck = false;
        PlayerStatus.noDamage = false;
        skill_timer = skilltime;
    }
    
    IEnumerator SkillCool ()
    {
        check = true;
        while (timer <= (CoolTimeUI.cooltime-4.0f))
        {
            timer += Time.deltaTime;
            yield return new WaitForSeconds(0.0f);
        }
        check = false;
        timer = 0.0f;
    }
    
}