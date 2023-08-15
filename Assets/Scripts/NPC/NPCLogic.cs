using System.Collections.Generic;
using UnityEngine;

public class NPCLogic : MonoBehaviour
{
    public List<MaterialType> wantedMaterials;
    public GameObject shape;

    GameObject root;

    void Awake()
    {
        root = GameObject.Find("RootSpawn");
        SpawnRoot();
    }
    
    void Update()
    {
        if(FindObjectOfType<OrderConsole>().orderStarted) FindObjectOfType<RootItem>().SetReqMaterial(wantedMaterials);
        else return;
    }

    public void SpawnRoot()
    {
        Instantiate(shape, root.transform.position, root.transform.rotation);
    }
}
