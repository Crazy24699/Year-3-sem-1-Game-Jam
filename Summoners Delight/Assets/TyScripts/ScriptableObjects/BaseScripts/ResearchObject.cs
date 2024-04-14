using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ResearchObject : ScriptableObject
{
    public new string name;
    public string description;
    public Sprite artwork;
    public int goldCost;

    public float effectValue;
    public abstract void UniqueEffect();
}
