using System.Collections.Generic;
using UnityEngine;

public class NPCLogic : MonoBehaviour
{
    public List<MaterialType> wantedMaterials;
    public GameObject shape;
    public float budget;
    public bool moneyPaid;

    public List<GameObject> Hairs;
    public List<GameObject> Glasses;

    public Transform hairPos;
    public Transform glassPos;

    GameObject root;

    void Awake()
    {
        root = GameObject.Find("RootSpawn");
        SpawnRoot();

        //Instancing
        Instantiate(Hairs[Random.Range(0,Hairs.Count)], hairPos);
        Instantiate(Glasses[Random.Range(0,Glasses.Count)], glassPos);
        
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
