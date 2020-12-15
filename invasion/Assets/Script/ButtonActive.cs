using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActive : MonoBehaviour
{
    private bool _buttonActive;

    public void ClickButton()
    {
        if (!_buttonActive)
        {
            _buttonActive = true;
        }

        else
        {
            _buttonActive = false;
        }
    }
}
