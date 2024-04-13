using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Unity.Mathematics;
using UnityEngine;

public class TowerDefender : MonoBehaviour
{
    [SerializeField]protected bool TargetInRage;
    public GameObject CurrentTarget;

    protected float RotationSpeed = 180f;
    public float AngleOffset;

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

    protected void TrackTarget()
    {
        if(CurrentTarget!=null && TargetInRage)
        {
            Vector2 TargetDirection = CurrentTarget.transform.position - this.transform.position;
            float TargetAngle = Mathf.Atan2(TargetDirection.y, TargetDirection.x) * Mathf.Rad2Deg;
            Quaternion TargetRotation = Quaternion.Euler(0, 0, TargetAngle - AngleOffset);

            this.transform.rotation = Quaternion.RotateTowards(transform.rotation, TargetRotation, RotationSpeed * Time.deltaTime);
        }
    }

    public IEnumerator Attack()
    {
        //starts the animation, spawns the obejct and runs startup
        yield return new WaitForSeconds(1.5f);
        //fires the ball
    }

}
