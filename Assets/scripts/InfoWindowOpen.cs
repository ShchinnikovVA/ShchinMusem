using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class InfoWindowOpen : MonoBehaviour
{
    public TimerPrompt timerPrompt;
    private float _startPositionY;
    public void ShowWindow()
    {
        timerPrompt.SetPause(true);
        this.transform.DOMoveY(0, 1f);
    }
    public void CloseWindow()
    {
        timerPrompt.SetPause(false);
        this.transform.DOMoveY(_startPositionY, 1f);
    }
    private void Start()
    {
        _startPositionY = this.transform.position.y;
    }
}
