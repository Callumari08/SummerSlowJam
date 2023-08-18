using TMPro;
using UnityEngine;

public class DisplayMoney : MonoBehaviour
{
    public TMP_Text txt;

    void Update()
    {
        float amt = Mathf.Round(Money.Current * 100.0f) * 0.01f;
        txt.text = $"${amt:0.00}";
    }
}
