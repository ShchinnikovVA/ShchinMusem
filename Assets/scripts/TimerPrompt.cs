using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerPrompt : MonoBehaviour
{
    #region Timer For Game
    [Header("Фон карты")]
    public Image background;
    public Sprite imgNoStreets, imgStreets;
    [Header("Таймер")]
    public CanvasManager canvasManager;
    [Header("Таймер")]
    public Text timerText;
    public int timerMinute = 6;
    private int _m, _s;
    private bool _isStop;
    private bool _isPaused;
    [HideInInspector]
    public bool pointsMultiplier;
    public void NewStart()
    {
        _isPaused = false;
        _isStop = false;
        pointsMultiplier = true;
        _m = timerMinute -1;
        _s = 60;
        Clue(imgNoStreets);
        StartCoroutine("TimerClue");
    }
    public void Clue(Sprite sprite) => background.sprite = sprite;
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

        if(_m <= 0 && _s <= 0)
        {
            pointsMultiplier = false;
            Clue(imgStreets);
            _isStop = true;
            StopCoroutine("TimerClue");
            timerText.text = "0:00";
        }
        else if (!_isStop) StartCoroutine("TimerClue");
    }
    public void SetPause(bool isPaused)
    {
        if (_isPaused != isPaused)
        {
            _isPaused = isPaused; // решение проблемы с многократным запуском таймера
            if (!_isPaused) StartCoroutine("TimerClue");
            else StopCoroutine("TimerClue");
        }
    }
    public bool GetBoolPause() => _isPaused;
    public bool GetBoolMultiplier() => pointsMultiplier;
    #endregion
    #region Standby mode
    [Header("Таймер бездействия")]
    public Text SM_text;
    public int SM_minute = 3;
    private int _m_SM, _s_SM;
    private bool _isStop_SM;
    [Header("Таймер бездействия")]
    public InfoWindowOpen[] infoWindow;
    public void SM_start()
    {
        StopCoroutine("TimerStandbyMode");
        _isStop_SM = false;
        _m_SM = SM_minute - 1;
        _s_SM = 60;
        StartCoroutine("TimerStandbyMode");
        SM_text.gameObject.SetActive(false);
    }
    IEnumerator TimerStandbyMode()
    {
        yield return new WaitForSeconds(1f);
        if (_m_SM > 0 && _s_SM == 0)
        {
            _m_SM -= 1;
            _s_SM = 60;
        }

        _s_SM -= 1;
        //print(_m_SM + ":" + _s_SM);
        if (_m_SM <= 0 && _s_SM <= 30)
        {
            SM_text.gameObject.SetActive(true);
            SM_text.text = new string("Бездействие! До выхода в главное меню: " + _s_SM);
        }
        else SM_text.gameObject.SetActive(false);

        if (_m_SM <= 0 && _s_SM == 0)
        {
            pointsMultiplier = false;
            Clue(imgNoStreets);
            SM_StopTimer();
            InfoWindowsToStartPos();
            SM_text.gameObject.SetActive(false);
            canvasManager.Expentation();
            StopCoroutine("TimerStandbyMode");
        }
        else if (!_isStop_SM) StartCoroutine("TimerStandbyMode");
    }
    public void SM_StopTimer()
    {
        _isStop_SM = true;
        _isStop = true;
    }
    private void InfoWindowsToStartPos()
    {
        for (int i = 0; i < infoWindow.Length; i++)
        {
            infoWindow[i].FastStartPosition();
        }
    }

    #endregion
}
