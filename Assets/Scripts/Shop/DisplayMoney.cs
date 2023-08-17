using TMPro;
using UnityEngine;

public class DisplayMoney : MonoBehaviour
{
    public TMP_Text txt;

    void Update()
    {
        txt.text = $"${Money.Current}";
    }
}
