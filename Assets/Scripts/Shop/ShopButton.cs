using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShopButton : MonoBehaviour
{
    [Range(-1, 1)]
    public int addIndex;

    Shop shop;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print(transform.root.name);
            if (shop || transform.root.TryGetComponent(out shop))
            {
                shop.Selected += addIndex;

                if (addIndex == 0) shop.Buy();
            }
            else throw new System.Exception("Root does not have a Shop component!");
        }
    }
}