using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    public float scrollSpeed;
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        rb.velocity = new Vector2(0, scrollSpeed);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Choco");
        GameObject gm = collision.gameObject;
        if (gm.tag == "BG")
        {
            GetComponent<Transform>().position = new Vector2(0, 12.6f);
        }
    }
}
