using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class RootItem : MonoBehaviour
{
    public List<SubItem> subItems;
    public bool itemComplete;
    [Space]
    public UnityEvent OnItemComplete;

    private void OnEnable()
    {
        subItems = GetComponentsInChildren<SubItem>().ToList();
    }

    /// <summary>
    /// Check that all children have met their requirements
    /// </summary>
    public void CheckChildren()
    {
        bool allChildrenReady = true;

        foreach (SubItem subItem in subItems)
        {
            if (!subItem.hasPart) 
                allChildrenReady = false;
        }

        if (allChildrenReady)
        {
            itemComplete = true;
            OnItemComplete.Invoke();
        }
    }

    public void SetReqMaterial(List<MaterialType> mat)
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.GetComponent<SubItem>().requiredMaterial = mat[i];
        }
    }
    
    public void EmptyParts()
    {
        foreach (Transform child in transform)
        {
            foreach (Transform subChild in child.transform)
            {
                Destroy(subChild.gameObject);
            }
        }
    }
}
