using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BossState {
    idle, pattern1, pattern2, pattern3, pattern4, dead
}

public class BossController : Singletorn<BossController>
{

    private BossState state;
    private BossStatus _status;

    void Start()
    {
        state = BossState.idle;
        _status = GetComponent<BossStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case BossState.idle:
                //BossPattern1.Instance.StartPattern();
                state = BossState.pattern1;
                break;

            case BossState.pattern1:
                if(_status.percent < 0.75)
                {
                    //BossPattern1.Instance.StopPattern();
                    BossPattern2.Instance.StartPattern();
                    state = BossState.pattern2;
                }
                break;

            case BossState.pattern2:
                if (_status.percent < 0.5)
                {
                    BossPattern2.Instance.StopPattern();
                    //BossPattern3.Instance.StartPattern();
                    state = BossState.pattern3;
                }
                break;

            case BossState.pattern3:
                if (_status.percent < 0.25)
                {
                    //BossPattern3.Instance.StopPattern();
                    //BossPattern4.Instance.StartPattern();
                    state = BossState.pattern4;
                }
                break;

            case BossState.pattern4:
                if (_status.HP <= 0)
                {
                    //BossPattern4.Instance.StopPattern();
                    state = BossState.dead;
                }
                break;

            case BossState.dead:
                break;
        }
    }

    public void Init()
    {
        state = BossState.idle;
        _status.Init();
        transform.position = new Vector3(0, 0, 33);
    }

}