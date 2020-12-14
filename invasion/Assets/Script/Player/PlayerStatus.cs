using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerStatus : Singletorn<PlayerStatus>
{
    public float MaxHp;
    public float Hp;
    //[SerializeField] private float Hp;
    public int power = 1;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "bullet")
        {
            Hp -= 0.05f;

            other.gameObject.SetActive(false);//임시로 삭제

            if(Hp <= 0)
            {
                GameManager.Instance.GameOver();
            }

        }
    }
    
    public float percent
    {
        get
        {
            return Hp / (float)MaxHp;
        }
    }
    
    public void Start()
    {
        Init();
    }

    public void Init()
    {
        MaxHp = 1.0f;
        Hp = 1.0f;
        power = 1;

        transform.position = Vector3.zero;
    }

    

}