using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Skelly : MinionBase
{
    public bool AttackStarted = false;

    public GameObject Collisionref;

    // Start is called before the first frame update
    void Start()
    {
        WallDamage = 59;
        MinionStartup();
    }

    private void OnCollisionEnter2D(Collision2D CollisionObject)
    {
        if (CollisionObject.gameObject.CompareTag("Wall") || CollisionObject.gameObject.CompareTag("Tower"))
        {
            Debug.Log("ran");
            //CollisionObject.gameObject.GetComponent<WallHealth>().TakeDamage(WallDamage);
            StartCoroutine(AttackLoop(CollisionObject));
        }

    }

    private void OnTriggerEnter2D(Collider2D CollisionObject)
    {
        if (CollisionObject.CompareTag("Tower"))
        {
            Destination = CollisionObject.transform;
            AIDest.target = Destination;
        }
    }
    private void OnCollisionExit2D(Collision2D CollisionObject)
    {
        if (CollisionObject.gameObject.CompareTag("Wall") || CollisionObject.gameObject.CompareTag("Tower"))
        {
            AttackStarted = false;
            StopCoroutine(AttackLoop(null));
            Collisionref = null;

        }
    }

    public IEnumerator AttackLoop(Collision2D CollisionObjectRef)
    {
        Collisionref = CollisionObjectRef.gameObject;
        if (AttackStarted || Destination == null)
        {
            yield return null;
        }

        AttackStarted = true;
        for (int i = 0; i < 3; )
        {

            yield return new WaitForSeconds(0.55f);
            if (Destination != null && AttackStarted )
            {
                string ObjectTag = CollisionObjectRef.gameObject.tag;

                switch (ObjectTag)
                {
                    case "Last Target":
                        CollisionObjectRef.gameObject.GetComponent<StrongHold>().TakeDamage(WallDamage);
                        break;

                    case "Wall":
                        CollisionObjectRef.gameObject.GetComponent<WallHealth>().TakeDamage(WallDamage);
                        break;

                    case "Tower":
                        CollisionObjectRef.gameObject.GetComponent<TowerDefender>().TakeDamage(WallDamage);
                        break;
                }
                Debug.Log("you and i");
            }
            i++;

            if (i == 3)
            {
                HandleHealth(CurrentHealth);
            }
        }
    }

}
