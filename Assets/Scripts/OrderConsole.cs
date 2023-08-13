using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderConsole : MonoBehaviour
{
    public bool order_started;
    public List<GameObject> NPC_prefab;
    public Transform NPC_spawn_location;
    public List<string> order_materials;

    int NPC_number = 0;

    public void StartOrder()
    {
        if (!order_started)
        {
            Instantiate(NPC_prefab[NPC_number], NPC_spawn_location);
            order_started = true;
        }
    }

    public void EndOrder()
    {
        if (order_started)
        {
            Destroy(NPC_spawn_location.GetChild(0).gameObject);
            NPC_number += 1;
            order_started = false;
        }
    }

    public void SetMaterials(List<string> i)
    {
        order_materials = i;
    }
}
