using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementEditor : MonoBehaviour
{
    private Rigidbody2D rb;

    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");


        Vector2 dir = new Vector2(x, y);
        Move(dir);


    }
    private void Move(Vector2 dir)
    {
      rb.velocity = new Vector2(dir.x * moveSpeed, dir.y*moveSpeed);

    }
}
