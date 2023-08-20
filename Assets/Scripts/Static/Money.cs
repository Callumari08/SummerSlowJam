using System;
using UnityEngine;

public static class Money
{
    public static float DefaultCurrent = 5;

    /// <summary>
    /// The amount of money the player has.
    /// </summary>
    public static float Current
    {
        get => _Current;
        set
        {
            OnMoneyChange?.Invoke(typeof(Money), EventArgs.Empty);

            _Current = value;
        }
    }

    public static event EventHandler OnMoneyChange;

    static float _Current = DefaultCurrent;

    /// <summary>
    /// Change Current To Default Current
    /// </summary>
    public static void ResetMoney() => 
        _Current = DefaultCurrent;
}