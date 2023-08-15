using System.Collections.Generic;
using UnityEngine;

public class NPCLogic : MonoBehaviour
{
    public MaterialType wanted_material;
    
    void Update()
    {
        if(FindObjectOfType<OrderConsole>().orderStarted) FindObjectOfType<SubItem>().SetReqMaterial(wanted_material);
        else return;
    }
}
