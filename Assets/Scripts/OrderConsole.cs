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
    
    public void StartOrder()
    {
        if (!orderStarted)
        {
            Instantiate(NPC_prefab[WorkInfo.NPC_number], NPC_spawnLocation);
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
                FindObjectOfType<NPCDialogue>().NextEnd();
                if(!FindObjectOfType<NPCLogic>().moneyPaid)
                {
                    Money.Current += FindObjectOfType<NPCLogic>().budget;
                    FindObjectOfType<NPCLogic>().moneyPaid = true;
                }
                Invoke("EndOrder", 3);
            }
        }
        else return;
    }

    void EndOrder()
    {
        if (FindObjectOfType<NPCLogic>().moneyPaid)
        {
            foreach (Transform NPC in NPC_spawnLocation)
            {
                Destroy(NPC.gameObject);
            }
            FindObjectOfType<RootItem>().itemComplete = false;
            FindObjectOfType<RootItem>().EmptyParts();
            Destroy(FindObjectOfType<RootItem>().gameObject);
            WorkInfo.NPC_number += 1;
            orderStarted = false;
        }
        else return;
    }
}
