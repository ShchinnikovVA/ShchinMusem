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
    //public Image[] photoElements;
    [Header("Обучение")]
    public GameObject educationWindow;
    [Header("Окно выхода в меню")]
    public GameObject exitToGaleryWindow;
    [Header("Окно выхода из игры")]
    public GameObject exitAppWindow;
    [Header("Запуск таймера подсказки")]
    public TimerPrompt timerPrompt;
    #region Show/Hide Windows
    public void ShowLogWindow()
    {
        registerWindow.GetComponent<RectTransform>().DOLocalMoveY(0, 2.0f).SetEase(Ease.InOutCirc);
        educationWindow.GetComponent<RectTransform>().DOLocalMoveY(windowCord, 1f).SetEase(Ease.InExpo);
    }
    public void StartGame()
    {
        registerWindow.GetComponent<RectTransform>().DOLocalMoveY(-windowCord, 1.0f).SetEase(Ease.InExpo);
        timerPrompt.NewStart();
        HideAllImages();
    }
    public void ShowInfoWindow()
    {
        photoGalery.GetComponent<RectTransform>().DOLocalMoveY(windowCord, 2.0f).SetEase(Ease.OutQuint);
        educationWindow.GetComponent<RectTransform>().DOLocalMoveY(0, 2f).SetEase(Ease.OutQuad);
    }
    public void Expentation()
    {
        HideAllImages();
        registerWindow.GetComponent<RectTransform>().localPosition = new Vector2(0, -windowCord);
        educationWindow.GetComponent<RectTransform>().localPosition = new Vector2(0, -windowCord);
        photoGalery.GetComponent<RectTransform>().DOLocalMoveY(0, 1.0f).SetEase(Ease.OutQuint);
        inputField.text = "";
    }
    public void ShowExitWindow() => exitToGaleryWindow.GetComponent<RectTransform>().DOLocalMoveY(0, 2f).SetEase(Ease.OutQuad);
    public void HideExitWindow() => exitToGaleryWindow.GetComponent<RectTransform>().DOLocalMoveY(-windowCord, 1.0f).SetEase(Ease.InExpo);
    public void ShowExitAppWindow() => exitAppWindow.GetComponent<RectTransform>().DOLocalMoveY(0, 2f).SetEase(Ease.OutQuad);
    public void HideExitAppWindow() => exitAppWindow.GetComponent<RectTransform>().DOLocalMoveY(-windowCord, 1.0f).SetEase(Ease.InExpo);
    #endregion


    #region DoneImages
    [Header("Запуск таймера подсказки")]
    public MouseMove[] houseImg;
    public StreetID[] streets;
    private void HideAllImages()
    {
        for (int i = 0; i < houseImg.Length; i++)
        {
            houseImg[i].HideDoneImg();
        }
        for (int i = 0; i < streets.Length; i++)
        {
            streets[i].HideDoneButton();
        }
    }
    #endregion
}
