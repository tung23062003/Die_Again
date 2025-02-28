using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class GameConstants
{
    public static string win_area = "WinArea";
}

public static class GameEvent
{
    public static UnityEvent OnStartLevel = new();
    public static UnityEvent OnWinLevel = new();
    public static UnityEvent OnLoseLevel = new();

    public static UnityEvent<Transform> OnAddPlayer = new();
}
