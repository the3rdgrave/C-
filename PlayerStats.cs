﻿using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {
    //initializing the player stats.
    public static int Money;
    public int startMoney = 300;

    public static int Lives;
    public int startLives = 20;

    public static int Rounds;

    void Start()
    {
        Money = startMoney;
        Lives = startLives;

        Rounds = 0;
    }

    
}