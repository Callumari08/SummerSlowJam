using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OrderConsole : MonoBehaviour
{
    public bool orderStarted;
    public List<GameObject> NPC_prefab;
    public Transform NPC_spawnLocation;
    public MaterialType orderMaterial;

    int NPC_number = 0;

    public void StartOrder()
    {
        if (!orderStarted)
        {
            Instantiate(NPC_prefab[NPC_number], NPC_spawnLocation);
            orderStarted = true; 
        }
    }

    public void StartEndOrder()
    {
        if (orderStarted)
        {
            Invoke("EndOrder", 3);
            FindObjectOfType<NPCDialogue>().NextEnd();
        }
    }

    void EndOrder()
    {
        Destroy(NPC_spawnLocation.GetChild(0).gameObject);
        NPC_number += 1;
        orderStarted = false;
        FindObjectOfType<RootItem>().itemComplete = false;
        FindObjectOfType<SubItem>().EmptyParts();
    }
}
