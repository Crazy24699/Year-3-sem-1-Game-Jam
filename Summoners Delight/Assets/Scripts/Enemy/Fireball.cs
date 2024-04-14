using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fireball : ProjectileBase
{
    


    private void OnTriggerEnter2D(Collider2D CollisionObject)
    {
        if (CollisionObject.CompareTag("Minion"))
        {
            CollisionObject.GetComponent<MinionBase>().HandleHealth(-Damage);
            Destroy(this.gameObject);
        }
    }

}
