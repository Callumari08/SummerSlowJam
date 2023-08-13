using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderConsole : MonoBehaviour
{
    public bool orderStarted;
    public List<GameObject> NPC_prefab;
    public Transform NPC_spawnLocation;
    public List<string> orderMaterials;

    int NPC_number = 0;

    public void StartOrder()
    {
        if (!orderStarted)
        {
            Instantiate(NPC_prefab[NPC_number], NPC_spawnLocation);
            orderStarted = true;
        }
    }

    public void EndOrder()
    {
        if (orderStarted)
        {
            Destroy(NPC_spawnLocation.GetChild(0).gameObject);
            NPC_number += 1;
            orderStarted = false;
        }
    }

    public void SetMaterials(List<string> i)
    {
        orderMaterials = i;
    }
}
