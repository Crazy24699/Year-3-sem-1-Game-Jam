using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MinionBase : MonoBehaviour
{

    protected int MaxHealth;
    public int CurrentHealth;
    public int WallDamage;
    const int WaitTime=5;

    protected float CurrentTime;
    protected float BaseMoveSpeed;
    public float CurrentMoveSpeed;

    protected bool SetupRan = false;

    public Transform Destination;
    protected Rigidbody2D RB2D;


    public void MinionStartup()
    {
        RB2D = TryGetComponent<Rigidbody2D>(out RB2D)
            ? GetComponent<Rigidbody2D>()
            : this.AddComponent<Rigidbody2D>();
        RB2D.gravityScale = 0;
        RB2D.constraints = RigidbodyConstraints2D.FreezeRotation;


        SetupRan = true;
    }

    public IEnumerator StartupStatusCheck()
    {
        yield return new WaitForSeconds(WaitTime);
        if (!SetupRan)
        {
            MinionStartup();
        }
    }

    public void SetDestination()
    {

    }



}
