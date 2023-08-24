using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisplayMoney : MonoBehaviour
{
    public TMP_Text txt;
    public string menuScene;

    void Update()
    {
        if (SceneManager.GetActiveScene().name != menuScene)
        {
            txt.gameObject.SetActive(true);
            float amt = Mathf.Round(Money.Current * 100.0f) * 0.01f;
            txt.text = $"${amt:0.00}";
        }
        else txt.gameObject.SetActive(false);
    }
}
