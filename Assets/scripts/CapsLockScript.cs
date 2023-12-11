using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CapsLockScript : MonoBehaviour
{
    private bool _isCaps = true;
    public Text keyboardText;
    public InputField thisText;
    public GameObject[] buttonText;
    public void CapsLock()
    {
        _isCaps = !_isCaps;
        if (_isCaps)
        {
            for (int i = 0; i < buttonText.Length; i++)
            {
                buttonText[i].GetComponentInChildren<Text>().text = buttonText[i].GetComponentInChildren<Text>().text.Substring(0, 1).ToUpper();
            }
        }
        else
        {
            for (int i = 0; i < buttonText.Length; i++)
            {
                buttonText[i].GetComponentInChildren<Text>().text = buttonText[i].GetComponentInChildren<Text>().text.Substring(0, 1).ToLower();
            }
        }
    }
    public void DeleteLastChar()
    {
        thisText.text = thisText.text.Substring(0, thisText.text.Length - 1);
    }

    public void ClearStr()
    {
        thisText.text = "";
    }

    public void SetInFiButton(InputField text)
    {
        thisText = text;
        for (int i = 0; i < buttonText.Length; i++)
        {
            buttonText[i].GetComponent<KeyPadButton>().thisText = text;
        }
    }
    public void ChangeText()
    {
        keyboardText.text = thisText.text;
    }
}
