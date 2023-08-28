using UnityEngine;

public class Part : MonoBehaviour
{
    public MaterialType materialType;
    public float price = 10f;

    private void Awake()
    {
        SaveManager.parts.Add(this);
    }
}

public enum MaterialType
{
    Wood,
    Metal,
    Cloth,
    Wool
}