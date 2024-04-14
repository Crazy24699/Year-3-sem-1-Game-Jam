using Pathfinding;
using Pathfinding.Util;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MinionBase : MonoBehaviour
{

    [SerializeField ]protected int MaxHealth;
    public int CurrentHealth;
    public int WallDamage;
    const int WaitTime=5;

    protected float CurrentTime;
    protected float BaseMoveSpeed;
    public float CurrentMoveSpeed;

    [SerializeField] protected bool SetupRan = false;

    public Transform Destination;
    [SerializeField]protected Transform FinalDestination;
    protected Rigidbody2D RB2D;
    public GameObject DeathParticle;

    public LayerMask AttackLayers;

    [SerializeField]protected AIDestinationSetter AIDest;

    public void MinionStartup()
    {
        RB2D = TryGetComponent<Rigidbody2D>(out RB2D)
            ? GetComponent<Rigidbody2D>()
            : this.AddComponent<Rigidbody2D>();
        RB2D.gravityScale = 0;
        RB2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        CurrentHealth = MaxHealth;

        AIDest = GetComponent<AIDestinationSetter>();

        AIDest.target = Destination;


        SetupRan = true;
        SetDestination();
    }

    public IEnumerator StartupStatusCheck()
    {
        yield return new WaitForSeconds(WaitTime);
        if (!SetupRan)
        {
            MinionStartup();
        }
    }

    protected void FixedUpdate()
    {
        if(Destination == null && SetupRan)
        {
            SetDestination();
        }
    }

    //have some basic decision making that will make the enemy prioritize the defenses and or currency. 
    public void SetDestination()
    {
        if(FinalDestination == null)
        {
            FinalDestination = GameObject.FindGameObjectWithTag("Last Target").transform;
        }
        Vector2 Direction=FinalDestination.position-this.transform.position;
        RaycastHit2D RayHit = Physics2D.Raycast(this.transform.position, Direction, 500, AttackLayers);

        if (RayHit.collider != null)
        {
            Destination = RayHit.collider.transform;
            //AIDest.target = Destination;
        }

        //checks the distance between all objects via the ontriggerenter and then decides. 
        float Distance = 10;
        switch (Distance)
        {
            case < 0:
                break;
        }
    }

    public int HandleHealth(int HealthChange)
    {
        CurrentHealth += HealthChange;
        if(CurrentHealth <= 0)
        {
            //play death animation and sound
            Instantiate(DeathParticle, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }

        return CurrentHealth;
    }

}
