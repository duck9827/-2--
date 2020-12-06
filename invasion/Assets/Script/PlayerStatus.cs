using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public int life = 3;
    public int power = 1;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "bullet")
        {
            life -= 1;

            other.gameObject.SetActive(false);//임시로 삭제

            if(life == 0)
            {
                print("You dead");
            }

        }
    }

}
