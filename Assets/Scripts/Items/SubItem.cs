using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SubItem : MonoBehaviour
{
    public bool hasPart;
    public MaterialType requiredMaterial;

    public UnityEvent MaterialMet;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Part part))
        {
            if (part.materialType == requiredMaterial)
            {
                OnMaterialMet(part);
            }
        }
    }

    void OnMaterialMet(Part part)
    {
        part.transform.parent = transform;
        part.transform.localPosition = new(0, 0, 0);
        part.transform.rotation = transform.rotation;

        hasPart = true;
        transform.root.GetComponent<RootItem>().CheckChildren();

        Destroy(part.GetComponent<Collider>());
        Destroy(part.GetComponent<Rigidbody>());

        MaterialMet.Invoke();
    }

    public void SetReqMaterial(MaterialType i)
    {
        requiredMaterial = i;
    }

    public void EmptyParts()
    {
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
