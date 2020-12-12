using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStatus : MonoBehaviour
{
    public int HP;
    public int MaxHP;

    public float percent
    {
        get
        {
            return HP / (float)MaxHP;
        }
    }
    void Start()
    {
        Init();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "mybullet")
        {
            HP -= 1;

            other.gameObject.SetActive(false);//임시로 삭제
        }
    }
    public void Init()
    {
        HP = MaxHP;
    }
}
