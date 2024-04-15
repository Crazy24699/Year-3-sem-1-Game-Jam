using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float speed = 5f; // Speed of movement
    public Rigidbody2D rb;
    public Camera camera;
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.velocity = movement * speed;
        camera.orthographicSize += -Input.mouseScrollDelta.y;
        //Debug.Log(Input.mouseScrollDelta);
    }
    private void Start()
    {
        transform.position = ResourceScript.instance.playerPos;
    }
}
