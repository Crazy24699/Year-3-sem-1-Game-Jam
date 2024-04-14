using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IncreaseTech : ResearchObject
{
    public enum IncreaseType
    {
        mult,
        perSecRate
    }
    public IncreaseType increaseType;
    public abstract override void UniqueEffect();
}
