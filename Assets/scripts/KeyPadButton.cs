using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPadButton : MonoBehaviour
{
    private Text _buttonText;
    public InputField thisText;

    private void Start()
    {
        _buttonText = this.GetComponentInChildren<Text>();
        this.GetComponent<Button>().onClick.AddListener(() => AddButtonChar());
    }
    public void AddButtonChar()
    {
        thisText.text += _buttonText.text;
    }
    

    
}
