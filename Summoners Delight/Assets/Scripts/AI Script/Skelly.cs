using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Skelly : MinionBase
{
    public bool AttackStarted = false;

    public GameObject CurrentCollision;

    // Start is called before the first frame update
    void Start()
    {
        WallDamage = 59;
        MinionStartup();
        //GameManager.ManagerInstance.WorldUpdate.AddListener(() => StopCoroutine(AttackLoop()));
    }

    private void OnCollisionEnter2D(Collision2D CollisionObject)
    {
        if (CollisionObject.gameObject.CompareTag("Wall") || CollisionObject.gameObject.CompareTag("Tower"))
        {
            if (CollisionObject == null)
            {
                return;
            }
            Debug.Log("ran");
            //CollisionObject.gameObject.GetComponent<WallHealth>().TakeDamage(WallDamage);
            CurrentCollision = CollisionObject.gameObject;
            StartCoroutine(AttackLoop());
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
            StopCoroutine(AttackLoop());
            CurrentCollision = null;

        }
    }



    public IEnumerator AttackLoop()
    {
        if(CurrentCollision == null)
        {
            yield return null;
        }

        CurrentCollision = CurrentCollision.gameObject;
        if (AttackStarted || Destination == null)
        {
            yield return null;
        }
        string ObjectTag = CurrentCollision.gameObject.tag;
        AttackStarted = true;
        for (int i = 0; i < 3; )
        {
            if (Destination != null && AttackStarted && CurrentCollision != null) 
            {

                switch (ObjectTag)
                {
                    case "Last Target":
                        CurrentCollision.gameObject.GetComponent<StrongHold>().TakeDamage(WallDamage);
                        break;

                    case "Wall":
                        CurrentCollision.gameObject.GetComponent<WallHealth>().TakeDamage(WallDamage);
                        break;

                    case "Tower":
                        CurrentCollision.gameObject.GetComponent<TowerDefender>().TakeDamage(WallDamage);
                        break;
                }
            }
            i++;
            yield return new WaitForSeconds(0.55f);
            if (i == 3)
            {
                HandleHealth(CurrentHealth);
            }
        }
    }

}
