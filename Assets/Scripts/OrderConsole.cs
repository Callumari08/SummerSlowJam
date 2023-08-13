using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderConsole : MonoBehaviour
{
    public bool order_started;
    public GameObject[] NPC_prefab;
    public Transform NPC_spawn_location;
    public string[] order_materials;

    int NPC_number = 0;

    public void start_order()
    {
        if (!order_started)
        {
            Instantiate(NPC_prefab[NPC_number], NPC_spawn_location);
            order_started = true;
        }
    }

    public void end_order()
    {
        if (order_started)
        {
            Destroy(NPC_spawn_location.GetChild(0).gameObject);
            NPC_number += 1;
            order_started = false;
        }
    }

    public void set_materials(string[] i)
    {
        order_materials = i;
    }
}
