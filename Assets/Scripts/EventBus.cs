using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventBus 
{
    public static  Action <bool> OnMovementStateChange; 
    public static Action OnGetToLastWaypoint;
    public static Action OnEnemyDefeated;
    public static void EnemyDefeated() => OnEnemyDefeated?.Invoke();
    public static void GetToLastWaypoint() => OnGetToLastWaypoint?.Invoke();
    public static void MovementStateChange(bool changed) => OnMovementStateChange?.Invoke(changed);
}
