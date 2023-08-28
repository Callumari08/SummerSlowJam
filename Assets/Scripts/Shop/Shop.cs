using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public int Selected
    {
        get
        {
            return _selected;
        }
        set
        {
            Deselect();

            if (value >= products.Count)
                _selected = 0;

            else if (value < 0)
                _selected = products.Count - 1;

            else _selected = value;

            Select();
        }
    }
    [HideInInspector] public List<Product> products;
    public UnityEvent onBuy;
    public UnityEvent onInsufficentFunds;

    [SerializeField] RectTransform listGo;
    [SerializeField] Transform instantiatePos;

    int _selected;

    public void Buy()
    {
        Product product = products[Selected];

        if (Money.Current >= product.Price)
        {
            onBuy.Invoke();
            print($"buy {Money.Current}");

            Money.Current -= product.Price;

            Instantiate(product.productGo, instantiatePos.position, Quaternion.identity);
        }
        else
        {
            print($"no {Money.Current}");
            onInsufficentFunds.Invoke();
        }
    }

    void Deselect()
    {
        Product product = products[Selected];
        Graphic graphic = product.gameObject.GetComponent<Graphic>();

        graphic.color = product.originColor;
        product.prodNameTxt.fontStyle = FontStyles.Normal;
        product.priceTxt.fontStyle = FontStyles.Normal;
    }

    void Select()
    {
        Product product = products[Selected];
        Graphic graphic = product.gameObject.GetComponent<Graphic>();

        graphic.color *= ColorBlock.defaultColorBlock.selectedColor * 1.25f;
        product.prodNameTxt.fontStyle = FontStyles.Bold;
        product.priceTxt.fontStyle = FontStyles.Bold;
    }

    private void Awake()
    {
        products = listGo.GetComponentsInChildren<Product>().ToList();

        Select();
    }
}