using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    int score;
    string name;
}

public class ScoreSaver : MonoBehaviour
{
    public TimerPrompt timerPrompt;
    public MouseMove houseSettings;

    public Player[] players = new Player[10];
    
}

