using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerData
{

    public int highscore;


    public PlayerData (ScoreManager player)
    {
        highscore = player.highscore;
    }

}
