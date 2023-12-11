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
    public Text placeholder;
    [Header("Галерея")]
    public GameObject photoGalery;
    //public Image[] photoElements;
    [Header("Обучение")]
    public GameObject educationWindow;
    [Header("Окно выхода в меню")]
    public GameObject exitToGaleryWindow;
    [Header("Окно выхода из игры")]
    public GameObject exitToMenuButton;
    public GameObject exitAppWindow;
    [Header("Окно рекордов")]
    public GameObject recordsWindow;
    [Header("Окно Победы")]
    public GameObject wonWindow;
    [Header("Клавиатура")]
    public GameObject keyboard;
    [Header("Запуск таймера подсказки")]
    public TimerPrompt timerPrompt;
    [Header("Новый игрок")]
    public ScoreSaver scoreSaver;
    [HideInInspector]
    public int allStreetsDone;
    [HideInInspector]
    public bool isExitWindow = false;
    #region Show/Hide Windows
    public void OpenKeyboard()
    {
        keyboard.SetActive(true);
        registerWindow.GetComponent<RectTransform>().DOLocalMoveY(150, 0);
    }
    public void CloseKeyBoard(bool isLogWindow)
    {
        keyboard.SetActive(false);
        if(isLogWindow)registerWindow.transform.position = new Vector2(0, 0);
    }
    public void ShowLogWindow()
    {
        registerWindow.GetComponent<RectTransform>().DOLocalMoveY(0, 2.0f).SetEase(Ease.InOutCirc);
        educationWindow.GetComponent<RectTransform>().DOLocalMoveY(windowCord, 1f).SetEase(Ease.InExpo);
    }
    public void StartGame()
    {
        if (inputField.text != "")
        {
            scoreSaver.NewGame();
            scoreSaver.SavePlayerName();
            registerWindow.GetComponent<RectTransform>().DOLocalMoveY(-windowCord, 1.0f).SetEase(Ease.InExpo);
            timerPrompt.NewStart();
            timerPrompt.SM_start();
            HideAllImages();
            exitToMenuButton.SetActive(true);
            placeholder.text = "Ваше имя...";
            HouseUseble();
        }
        else
        {
            placeholder.text = "Введите ваше имя!";
        }
        
    }
    public void ShowInfoWindow()
    {
        photoGalery.GetComponent<RectTransform>().DOLocalMoveY(windowCord, 2.0f).SetEase(Ease.OutQuint);
        educationWindow.GetComponent<RectTransform>().DOLocalMoveY(0, 2f).SetEase(Ease.OutQuad);
    }
    public void Expentation()
    {
        allStreetsDone = 0;
        scoreSaver.SaveToList();
        scoreSaver.TextUpdate(0);
        scoreSaver.SaveAllPlayerProperties("/musemSaveData.txt");
        timerPrompt.SM_StopTimer();
        HideAllImages();
        registerWindow.GetComponent<RectTransform>().localPosition = new Vector2(0, -windowCord);
        HideLogWindow();
        CloseAllInfoWindows();
    }
    public void HideLogWindow()
    {
        educationWindow.GetComponent<RectTransform>().localPosition = new Vector2(0, -windowCord);
        inputField.text = "";
        registerWindow.GetComponent<RectTransform>().DOLocalMoveY(-windowCord, 1.0f).SetEase(Ease.OutQuint);
        photoGalery.GetComponent<RectTransform>().DOLocalMoveY(0, 1.0f).SetEase(Ease.OutQuint);
    }
    //public void NameLenght()
    //{
    //    if (inputField.text.Length > 20) inputField.text = inputField.text.Substring(0, 20);
    //}
    public void ShowExitWindow()
    {
        exitToGaleryWindow.GetComponent<RectTransform>().DOLocalMoveY(0, 2f).SetEase(Ease.OutQuad);
        isExitWindow = true;
    }
    public void HideExitWindow()
    {
        exitToGaleryWindow.GetComponent<RectTransform>().DOLocalMoveY(-windowCord, 1.0f).SetEase(Ease.InExpo);
        isExitWindow = false;
    }
    public void ShowExitAppWindow() => exitAppWindow.GetComponent<RectTransform>().DOLocalMoveY(0, 2f).SetEase(Ease.OutQuad);
    public void HideExitAppWindow() => exitAppWindow.GetComponent<RectTransform>().DOLocalMoveY(-windowCord, 1.0f).SetEase(Ease.InExpo);
    public void ShowRecordWindow() => recordsWindow.GetComponent<RectTransform>().DOLocalMoveY(0, 1f).SetEase(Ease.OutQuad);
    public void HideRecordWindow() => recordsWindow.GetComponent<RectTransform>().DOLocalMoveY(-windowCord, 1.0f).SetEase(Ease.InExpo);
    public void WinGame()
    {
        if (allStreetsDone >= 17)
        {
            wonWindow.GetComponent<RectTransform>().DOLocalMoveY(0, 1f).SetEase(Ease.OutQuad);
            CloseAllInfoWindows();
        }
    }
    public void CloseAllInfoWindows()
    {
        for (int i = 0; i < houseImg.Length; i++)
        {
            houseImg[i].infoWindow.CloseWindow();
        }
    }
    public void HideWonWindow() => wonWindow.GetComponent<RectTransform>().DOLocalMoveY(-windowCord, 1.0f).SetEase(Ease.InExpo);
    #endregion


    #region DoneImages
    [Header("Элементы для взаимодействия")]
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
    private void HouseUseble()
    {
        for (int i = 0; i < houseImg.Length; i++)
        {
            houseImg[i].CanDrag();
        }
        for (int i = 0; i < streets.Length; i++)
        {
            streets[i].GetComponent<Collider2D>().enabled = true;
        }
    }
    #endregion
}
