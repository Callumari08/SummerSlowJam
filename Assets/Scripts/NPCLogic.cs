using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCLogic : MonoBehaviour
{
    public string[] wanted_materials;
    
    public GameObject text_bubble;

    void Awake()
    {
        text_bubble.SetActive(true);
        FindObjectOfType<OrderConsole>().set_materials(wanted_materials);
    }
}
