using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHorde : MonoBehaviour
{
    public Transform horde;
    public Vector2 mouseToWorld;
    public Vector2 hordepos;
    bool moving = false;
    // Start is called before the first frame update
    void Start()
    {
        
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
            transform.position = Vector2.MoveTowards(horde.position, mouseToWorld, 1 * Time.deltaTime);
            if((Vector2)transform.position == mouseToWorld)
            {
                moving = false;
            }
        }
        
    }
}
