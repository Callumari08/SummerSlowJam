using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Product : MonoBehaviour
{
    public string ProductName
    {
        get
        {
            return _productName;
        }
        set
        {
            prodNameTxt.text = value;
            _productName = value;
        }
    }

    public float Price
    {
        get
        {
            

            return _price;
        }
        set
        {
            priceTxt.text = $"${value}";
            _price = value;
        }
    }

    [SerializeField] string _productName;
    [SerializeField] float _price;
    public GameObject productGo;
    public TextMeshProUGUI prodNameTxt;
    public TextMeshProUGUI priceTxt;
    [HideInInspector] public Color originColor;

    private void OnValidate()
    {
        prodNameTxt.text = _productName;
        priceTxt.text = $"${_price}";
    }

    private void Awake()
    {
        originColor = GetComponent<Image>().color;
    }
}