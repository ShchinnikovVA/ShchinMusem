using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public float windowCord = 1100.0f;
    [Header("Окно регистрации")]
    public GameObject registerWindow;
    public InputField inputField;
    [Header("Галерея")]
    public GameObject photoGalery;
    public Image[] photoElements;
    [Header("Обучение")]
    public GameObject educationWindow;
    [Header("Запуск таймера подсказки")]
    public TimerPrompt timerPrompt;

    public void ShowLogWindow()
    {
        registerWindow.GetComponent<RectTransform>().DOLocalMoveY(0, 2.0f).SetEase(Ease.InOutCirc);
        educationWindow.GetComponent<RectTransform>().DOLocalMoveY(windowCord, 1f).SetEase(Ease.InExpo);
    }
    public void StartGame()
    {
        registerWindow.GetComponent<RectTransform>().DOLocalMoveY(-windowCord, 1.0f).SetEase(Ease.InExpo);
        timerPrompt.NewStart();
    }
    public void ShowInfoWindow()
    {
        photoGalery.GetComponent<RectTransform>().DOLocalMoveY(windowCord, 2.0f).SetEase(Ease.OutQuint);
        educationWindow.GetComponent<RectTransform>().DOLocalMoveY(0, 2f).SetEase(Ease.OutQuad);
    }
    public void Expentation()
    {
        photoGalery.GetComponent<RectTransform>().DOLocalMoveY(0, 1.0f).SetEase(Ease.OutQuint);
    }
}
