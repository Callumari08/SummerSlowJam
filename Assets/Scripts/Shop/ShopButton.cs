using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButton : MonoBehaviour
{
    [Range(-1, 1)]
    public int addIndex;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Shop shop = transform.root.GetComponent<Shop>();

            shop.Selected += addIndex;

            if (addIndex == 0) shop.Buy();
        }
    }
}