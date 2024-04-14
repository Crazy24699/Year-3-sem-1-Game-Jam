using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bodies Research", menuName = "Research/Bodies Research")]
public class BodiesTech : IncreaseTech
{
    public override void UniqueEffect()
    {
        switch (increaseType)
        {
            case IncreaseType.mult:
                ResourceScript.instance.IncreaseBodiesMult(Mathf.RoundToInt(effectValue));
                break;
            case IncreaseType.perSecRate:
                ResourceScript.instance.IncreaseBodiesRate(effectValue);
                break;
        }
    }
}
