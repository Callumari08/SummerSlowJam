using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class SubItem : MonoBehaviour
{
    public bool hasPart;
    public List<MaterialType> requiredMaterials;

    public UnityEvent MaterialMet;
    Collider col;

    private void OnEnable()
    {
        col = GetComponent<Collider>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Part part))
        {
            foreach (MaterialType mat in requiredMaterials)
            {
                if (part.materialType == mat)
                {
                    OnMaterialMet(part);
                }
            }
        }
    }

    void OnMaterialMet(Part part)
    {
        part.transform.parent = transform;
        part.transform.localPosition = new(0, 0, 0);
        part.transform.rotation = transform.rotation;

        hasPart = true;
        col.isTrigger = false;
        transform.root.GetComponent<RootItem>().CheckChildren();
        
        Destroy(part.GetComponent<Collider>());
        Destroy(part.GetComponent<Rigidbody>());

        MaterialMet.Invoke();
    }
}
