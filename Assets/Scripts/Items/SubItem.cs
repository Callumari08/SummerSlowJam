using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class SubItem : MonoBehaviour
{
    public bool hasPart;
    public MaterialType requiredMaterial;
    [Space]
    public UnityEvent OnMaterialMet;

    Collider col;

    private void OnEnable()
    {
        col = GetComponent<Collider>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Part part))
        {
            if (part.materialType == requiredMaterial)
            {
                MaterialMet(part);
            }
        }
    }

    void MaterialMet(Part part)
    {
        part.transform.parent = transform;
        part.transform.localPosition = new(0, 0, 0);
        part.transform.rotation = transform.rotation;

        if (transform.TryGetComponent(out Renderer rend))
            Destroy(rend);

        hasPart = true;
        col.isTrigger = false;
        transform.root.GetComponent<RootItem>().CheckChildren();
        
        Destroy(part.GetComponent<Collider>());
        Destroy(part.GetComponent<Rigidbody>());

        OnMaterialMet.Invoke();
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
