using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gold Research", menuName = "Research/Gold Research")]
public class GoldTech : IncreaseTech
{
    public override void UniqueEffect()
    {
        switch(increaseType)
        {
            case IncreaseType.mult:
                ResourceScript.instance.IncreaseGoldMult(Mathf.RoundToInt(effectValue));
            break;
            case IncreaseType.perSecRate:
                ResourceScript.instance.IncreaseGoldRate(effectValue);
            break;
        }
    }
}
