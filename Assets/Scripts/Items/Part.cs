using UnityEngine;

public class Part : MonoBehaviour
{
    public MaterialType materialType;
}

public enum MaterialType
{
    Wood,
    Metal,
    Cloth,
    Wool
}