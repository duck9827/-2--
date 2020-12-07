using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//임시 스크립트
public class PlayerController : MonoBehaviour
{
    public float playerspeed = 1;
    public float jumpPower = 50f;

    private Rigidbody rigidbody;

    //private bool isJumping;
    
    void Start()
    {
        // 힘을 가하기 위해 게임 오브젝트에 추가된 Rigidbody 컴포넌트의 인스턴스를 얻는다.
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));

        transform.position += direction * playerspeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Z)) //z키를 누를시 공격 
        {
            GameObject o = ObjectPoolManager.Instance.Spawn("myB", transform.position, transform.rotation);
            o.GetComponent<Rigidbody>().AddForce(transform.forward * 5);
        }

        if (Input.GetKeyDown(KeyCode.Space)) //스페이스바를 누를 시 점프
        {
            rigidbody.AddForce(Vector3.up * jumpPower , ForceMode.Impulse);
        }
    }


}
