using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[System.Serializable]
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
    [Header("Текст имя и счёт")]
    public Text[] textName = new Text[10];
    public Text[] textRecord = new Text[10];
    
    [Header(" ")]
    public Player[] players = new Player[10];
    private Player thisPlayer;
    #region Saver
    public void NewGame() => thisPlayer = new Player();
    public void SavePlayerName() => thisPlayer.playerName = nameStr.text;
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
    public void SaveAllPlayerProperties(string patchname)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string savepatch = Application.persistentDataPath + patchname;
        FileStream stream = new FileStream(savepatch, FileMode.Create);
        formatter.Serialize(stream, players);
        stream.Close();
    }
    public static Player[] LoadPlayerList()
    {
        string savepatch = Application.persistentDataPath + "/musemSaveData.txt";
        if (File.Exists(savepatch))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(savepatch, FileMode.Open);
            Player[] saveData = formatter.Deserialize(stream) as Player[];
            stream.Close();
            return saveData;
        }
        else return null;
    }
    public void SaveToList()
    {
        if (thisPlayer.score > players[9].score)
        {
            players[9] = thisPlayer;
            SortPlayerList();
        }
    }
    private void SortPlayerList()
    {
        for (int i = 0; i < players.Length; i++)
        {
            for (int j = 0; j < players.Length; j++)
            {
                if (j + 1 < players.Length && players[j].score < players[j + 1].score)
                {
                    var bubble = players[j];
                    players[j] = players[j + 1];
                    players[j + 1] = bubble;
                }
            }
        }
        for (int j = 0; j < players.Length; j++)
        {
            textName[j].text = players[j].playerName;
            textRecord[j].text = players[j].score.ToString();
        }
    }
    private void Start()
    {
        if (LoadPlayerList() != null)
        {
            players = LoadPlayerList();
        }
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i] == null)
            {
                players[i] = new Player();
                players[i].playerName = "Фамилия Имя Отчество";
                players[i].score = 0;
            }
        }
        SortPlayerList();
    }
    #endregion
    #region Cleaner
    [Header("Значение и Пароль для сброса таблицы")]
    public InputField inputCount;
    public InputField inputPassword;
    public GameObject warningText;

    public void AcceptClean()
    {
        bool _isPassword = false;
        bool _isCount = false;
        if (inputPassword.text != "vhj14gbd73") warningText.SetActive(true);
        else _isPassword = true;
        switch (inputCount.text)
        {
            case "1":
                players[0] = new Player();
                players[0].playerName = "Фамилия Имя Отчество";
                players[0].score = 0;
                _isCount = true;
                break;
            case "2":
                players[1] = new Player();
                players[1].playerName = "Фамилия Имя Отчество";
                players[1].score = 0;
                _isCount = true;
                break;
            case "3":
                players[2] = new Player();
                players[2].playerName = "Фамилия Имя Отчество";
                players[2].score = 0;
                _isCount = true;
                break;
            case "4":
                players[3] = new Player();
                players[3].playerName = "Фамилия Имя Отчество";
                players[3].score = 0;
                _isCount = true;
                break;
            case "5":
                players[4] = new Player();
                players[4].playerName = "Фамилия Имя Отчество";
                players[4].score = 0;
                _isCount = true;
                break;
            case "6":
                players[5] = new Player();
                players[5].playerName = "Фамилия Имя Отчество";
                players[5].score = 0;
                _isCount = true;
                break;
            case "7":
                players[6] = new Player();
                players[6].playerName = "Фамилия Имя Отчество";
                players[6].score = 0;
                _isCount = true;
                break;
            case "8":
                players[7] = new Player();
                players[7].playerName = "Фамилия Имя Отчество";
                players[7].score = 0;
                _isCount = true;
                break;
            case "9":
                players[8] = new Player();
                players[8].playerName = "Фамилия Имя Отчество";
                players[8].score = 0;
                _isCount = true;
                break;
            case "10":
                players[9] = new Player();
                players[9].playerName = "Фамилия Имя Отчество";
                players[9].score = 0;
                _isCount = true;
                break;
            case "ВСЕ":
                for (int i = 0; i < players.Length; i++)
                {
                    players[i] = new Player();
                    players[i].playerName = "Фамилия Имя Отчество";
                    players[i].score = 0;
                }
                _isCount = true;
                break;
            default:
                warningText.SetActive(true);
                break;
        }
        if (_isCount & _isPassword)
        {
            SortPlayerList();
            inputCount.text = "";
            inputPassword.text = "";
            warningText.SetActive(true);
            SaveAllPlayerProperties("/musemSaveData.txt");
        }
    }
    #endregion
}

