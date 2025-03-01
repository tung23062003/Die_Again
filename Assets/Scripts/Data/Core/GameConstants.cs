using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class GameConstants
{
    public static string win_area = "WinArea";
    public static string dead_zone = "Deadzone";
}

public static class GameEvent
{
    public static UnityEvent OnStartLevel = new();
    public static UnityEvent OnWinLevel = new();
    public static UnityEvent OnLoseLevel = new();
    public static UnityEvent<EndLevelType> OnEndLevel = new();

    public static UnityEvent<Transform> OnAddPlayer = new();
}

public enum EndLevelType
{
    Win = 0,
    Lose = 1
}
