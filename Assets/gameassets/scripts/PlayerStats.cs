using System.Collections;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 400;

    public static int Lives;
    public int startLives = 100;

    public static int Rounds;

    void Start()
    {
        Rounds = 0;
        Money = startMoney;
        Lives = startLives;
    }

    
}
