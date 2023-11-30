using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerPrompt : MonoBehaviour
{
    public Image background;
    public Sprite imgNoStreets, imgStreets;
    public Text timerText;
    public int timerMinute = 6;
    private int _m, _s = 60;
    private bool _isStop = false;
    private bool _isPaused = false;
    [HideInInspector]
    public bool pointsMultiplier;
    public void NewStart()
    {
        pointsMultiplier = true;
        _m = timerMinute -1;
        background.sprite = imgNoStreets;
        StartCoroutine("TimerClue");
    }

    public void Clue() => background.sprite = imgStreets;

    IEnumerator TimerClue()
    {
        yield return new WaitForSeconds(1f);
        //print(_m + ":" + _s);
        if (_m > 0 && _s == 0)
        {
            _m -= 1;
            _s = 60;
        }

        _s -= 1;
        var _Sstr = new string(_s + "");
        if (_s < 10) _Sstr = new string("0" + _s);
        
        timerText.text = new string(_m + ":" + _Sstr);

        if(_m <= 0 && _s == 0)
        {
            pointsMultiplier = false;
            Clue();
            _isStop = true;
            StopCoroutine("TimerClue");
        }
        else if (!_isStop) StartCoroutine("TimerClue");
    }
    public void SetPause(bool isPaused)
    {
        _isPaused = isPaused;
        if (!_isPaused) StartCoroutine("TimerClue");
        else StopCoroutine("TimerClue");
    }
    public bool GetBoolPause() => _isPaused;

}
