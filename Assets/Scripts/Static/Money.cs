using System;
using System.ComponentModel;

public static class Money
{
    public static float DefaultCurrent;

    /// <summary>
    /// The amount of money the player has.
    /// </summary>
    public static float Current
    {
        get
        {
            return _Current;
        }
        set
        {
            OnMoneyChange?.Invoke(typeof(Money), EventArgs.Empty);

            _Current = value;
        }
    }

    public static event EventHandler OnMoneyChange;

    static float _Current = DefaultCurrent;

    public static void ResetMoney()
    {
        _Current = DefaultCurrent;
    }
}
