using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerStatus : Singletorn<PlayerStatus>
{
    public int life = 3;
    public int power = 1;
    [SerializeField] private Camera cam;
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
    
    private void Update()
    {
        var dir = (cam.transform.forward *
            Input.GetAxis("Vertical") + cam.transform.right * Input.GetAxis("Horizontal")).normalized;
        
        
        //보는 방향으로 플레이어 회전
        transform.rotation = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.z) * -1);
    }
    
    
    public void Init()
    {
        life = 3;
        power = 1;

        transform.position = Vector3.zero;
    }

    

}

