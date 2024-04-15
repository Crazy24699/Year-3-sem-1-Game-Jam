using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHorde : MonoBehaviour
{
    public Transform horde;
    public Vector2 mouseToWorld;
    public Vector2 hordepos;
    public float hordeSpeed = 1;
    bool moving = false;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = ResourceScript.instance.playerPos;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            moving = true;
            mouseToWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
        }
        if(moving == true)
        {
            transform.position = Vector2.MoveTowards(horde.position, mouseToWorld, hordeSpeed * Time.deltaTime);
            if((Vector2)transform.position == mouseToWorld)
            {
                moving = false;
            }
        }
        ResourceScript.instance.playerPos = transform.position;
    }
}
