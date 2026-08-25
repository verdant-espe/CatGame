using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System;

// Allows inventory to be used idk
[CreateAssetMenu]
public class InteractablesDatabase : ScriptableObject
{
    // Creates a list for the interactables
    public List <InteractableData> interactableData;
}

[Serializable]

// Defines InteractableData
public class InteractableData
{

    // Displays interactable properties in inspector
    [field: SerializeField]

    // Defines name of interactable
    public string Name { get; private set; }
    [field: SerializeField]

    // Defines ID of interactable
    public int ID { get; private set; }
    [field: SerializeField]

    // Defines size of interactable
    public Vector2Int Size { get; private set; } = Vector2Int.one;
    [field: SerializeField]

    // Defines interactable prefab
    public GameObject Prefab { get; private set; }
}

