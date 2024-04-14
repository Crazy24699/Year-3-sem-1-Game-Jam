using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Skelly : MinionBase
{
    public bool AttackStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        WallDamage = 59;
        MinionStartup();
    }

    private void OnCollisionEnter2D(Collision2D CollisionObject)
    {
        if (CollisionObject.gameObject.CompareTag("Wall"))
        {
            Debug.Log("ran");
            //CollisionObject.gameObject.GetComponent<WallHealth>().TakeDamage(WallDamage);
            StartCoroutine(AttackLoop(CollisionObject));
        }
    }

    public IEnumerator AttackLoop(Collision2D CollisionObjectRef)
    {
        if (AttackStarted || Destination == null)
        {
            yield return null;
        }

        AttackStarted = true;
        for (int i = 0; i < 3; )
        {

            yield return new WaitForSeconds(0.55f);
            if (Destination != null)
            {
                CollisionObjectRef.gameObject.GetComponent<WallHealth>().TakeDamage(WallDamage);
            }

            
            i++;

            if (i == 3)
            {
                HandleHealth(CurrentHealth);
            }
        }
    }

}
