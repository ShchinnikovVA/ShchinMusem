using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player
{
    [HideInInspector]
    public int score;
    [HideInInspector]
    public string playerName;

}

public class ScoreSaver : MonoBehaviour
{
    [Header("Ссылки")]
    public TimerPrompt timerPrompt;
    public InputField nameStr;
    public Text bg_score, ew_score;

    [Header(" ")]
    public Player[] players = new Player[10];
    private Player thisPlayer;

    public void NewGame()
    {
        thisPlayer = new Player();
    }
    public void SavePlayerName()
    {
        thisPlayer.playerName = nameStr.text;
    }
    public void SavePlayerScore(int _score)
    {
        if (timerPrompt.GetBoolMultiplier()) thisPlayer.score += _score * 2;
        else thisPlayer.score += _score;
    }

    public void TextUpdate()
    {
        bg_score.text = new string("Очки: " + thisPlayer.score);
        ew_score.text = new string("Вы набрали " + thisPlayer.score + " баллов");
    }
    public void TextUpdate(int _score)
    {
        bg_score.text = new string("Очки: " + _score);
        ew_score.text = new string("Вы набрали " + _score + " баллов");
    }

}

