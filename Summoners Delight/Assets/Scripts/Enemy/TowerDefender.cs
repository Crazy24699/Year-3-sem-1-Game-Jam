using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Unity.Mathematics;
using UnityEngine;

public class TowerDefender : MonoBehaviour
{
    [SerializeField]protected bool TargetInRage;

    public GameObject CurrentTarget;
    public GameObject FireballRef;
    public Transform FirePoint;

    protected float RotationSpeed = 180f;
    public float AngleOffset;

    public int MaxHeath;
    public int CurrentHealth;

    [SerializeField]protected bool CanAttack = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TrackTarget();

    }

    private void OnTriggerStay2D(Collider2D CollisionObject)
    {
        if (CollisionObject.CompareTag("Minion") && !TargetInRage)
        {
            CurrentTarget = CollisionObject.gameObject;
            TargetInRage = true;
        }
    }
    private void OnTriggerExit2D(Collider2D CollisionObject)
    {
        if (CollisionObject.CompareTag("Minion") && TargetInRage)
        {
            CurrentTarget = null;
            TargetInRage = false;
        }

    }

    public int TakeDamage(int Damage)
    {
        CurrentHealth -= Damage;
        if(CurrentHealth <= 0)
        {
            Destroy(this.gameObject); 
            return 0;
        }
        return CurrentHealth;
    }

    protected void TrackTarget()
    {
        if(CurrentTarget!=null && TargetInRage)
        {
            Vector2 TargetDirection = CurrentTarget.transform.position - this.transform.position;
            float TargetAngle = Mathf.Atan2(TargetDirection.y, TargetDirection.x) * Mathf.Rad2Deg;
            Quaternion TargetRotation = Quaternion.Euler(0, 0, TargetAngle + AngleOffset);

            this.transform.rotation = Quaternion.RotateTowards(transform.rotation, TargetRotation, RotationSpeed * Time.deltaTime);
            if (CanAttack)
            {
                
                StartCoroutine(Attack(TargetAngle - AngleOffset));
                CanAttack = false;
            }

        }
    }

    public IEnumerator Attack(float RotationAngle)
    {
        if (!CanAttack)
        {
            yield return null;
        }
        GameObject SpawnedProjectile;
        SpawnedProjectile = Instantiate(FireballRef, FirePoint.position, FirePoint.rotation);
        CanAttack = false;

        SpawnedProjectile.transform.localScale /= 2;
        SpawnedProjectile.GetComponent<ProjectileBase>().Startup();
        //starts the animation, spawns the obejct and runs startup
        yield return new WaitForSeconds(1.5f);

        //fires the ball

        yield return new WaitForSeconds(2.5f);
        CanAttack = true;
    }

}
