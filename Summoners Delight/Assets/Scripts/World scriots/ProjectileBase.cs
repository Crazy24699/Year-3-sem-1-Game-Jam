using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    public int Damage;

    public float MoveSpeed;

    public GameObject ProjectileRef;
    public Rigidbody2D RB2D;

    public void Startup()
    {
        ProjectileRef = this.gameObject;
        RB2D = this.GetComponent<Rigidbody2D>();
        if(RB2D == null )
        {
            this.gameObject.AddComponent<Rigidbody2D>();
        }


    }

    public void ApplyForce()
    {

    }

}
