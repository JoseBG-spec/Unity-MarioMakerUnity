using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public LayerMask groundLayer;
    public bool onGround;
    public Vector2 sizeX;
    public Vector2 bottomOffset;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        onGround = Physics2D.OverlapBox((Vector2)transform.position + bottomOffset, sizeX, 0, groundLayer.value);
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireCube((Vector2)transform.position + bottomOffset, sizeX);
    }
}
