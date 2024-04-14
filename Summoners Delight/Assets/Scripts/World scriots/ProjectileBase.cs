using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    public int Damage;

    public float MoveSpeed;
    protected float CurrentTime;
    protected float ScaleTime=1.5f;

    protected bool StartScaling = false;

    public GameObject ProjectileRef;
    public Rigidbody2D RB2D;

    [SerializeField]protected Vector3 InitialScale;
    [SerializeField]protected Vector3 NormalScale = Vector3.one;

    public void Startup()
    {
        ProjectileRef = this.gameObject;
        RB2D = this.GetComponent<Rigidbody2D>();
        if(RB2D == null )
        {
            this.gameObject.AddComponent<Rigidbody2D>();
        }
        RB2D.gravityScale = 0;

        this.transform.localScale = transform.localScale/2;
        InitialScale = this.transform.localScale;
        StartScaling = true;


    }

    private void Update()
    {
        if (StartScaling ) 
        {
            Debug.Log("rites");
            CurrentTime += Time.deltaTime;
            float ScaleFactor = Mathf.Clamp01(CurrentTime / ScaleTime);
            transform.localScale=Vector3.Lerp(InitialScale, NormalScale, ScaleFactor);
        }
        if ((this.transform.localScale.x > NormalScale.x || this.transform.localScale == NormalScale) &&  StartScaling )
        {
            ApplyForce();
            this.transform.localScale = NormalScale;
            StartScaling = false;
        }
    }

    public void ApplyForce()
    {
        Debug.Log("Moon");
        RB2D.velocity = -transform.up * MoveSpeed;
    }

}
