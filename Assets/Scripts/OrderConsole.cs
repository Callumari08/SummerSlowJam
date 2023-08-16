using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OrderConsole : MonoBehaviour
{
    public bool orderStarted;
    public List<GameObject> NPC_prefab;
    public Transform NPC_spawnLocation;
    public UnityEvent OnOrderStarted;
    
    int NPC_number = 0;

    public void StartOrder()
    {
        if (!orderStarted)
        {
            Instantiate(NPC_prefab[NPC_number], NPC_spawnLocation);
            if(!FindObjectOfType<RootItem>().itemComplete)
            {
                orderStarted = true; 
                OnOrderStarted.Invoke();
            }
        }
        else return;
    }

    public void StartEndOrder()
    {
        if (orderStarted)
        {
            if(FindObjectOfType<RootItem>().itemComplete)
            {
                Invoke("EndOrder", 3);
                FindObjectOfType<NPCDialogue>().NextEnd();
            }
        }
    }

    void EndOrder()
    {
        Destroy(NPC_spawnLocation.GetChild(0).gameObject);
        NPC_number += 1;
        orderStarted = false;
        FindObjectOfType<RootItem>().itemComplete = false;
        FindObjectOfType<RootItem>().EmptyParts();
        Destroy(FindObjectOfType<RootItem>().gameObject);
    }
}
