using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolTimeUI : MonoBehaviour
{
    public Image image;
    public Button button;
    public float coolTime = 10.0f;
    public bool isCool = true;
    private float leftTime = 10.0f;
    private float speed = 5.0f;
    void Update()
    {
        if (isCool)
        {
            if (leftTime > 0)
            {
                leftTime -= Time.deltaTime * speed;
                if(leftTime < 0) {
                    leftTime = 0;
                    if(button)
                        button.enabled = true;
                    isCool = true;   
                }

                float ratio = 1.0f - (leftTime / coolTime);
                if(image)
                    image.fillAmount = ratio;
            }
        }
    }

    public void StartCoolTime() {
        leftTime = coolTime;
        isCool = true;
        if(button)
            button.enabled = false; // 버튼 기능을 해지함.
    }
}
