using UnityEngine;
using UnityEngine.UI;

public class VisualDayNight : MonoBehaviour
{
    public Image img;

    public Sprite day;
    public Sprite night;

    public void SetImgDay() { img.sprite = day; }
    public void SetImgNight() { img.sprite = night; }
}
