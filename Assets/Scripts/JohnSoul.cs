using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnSoul : MonoBehaviour
{

    private Rigidbody2D Rigidbody2D;
    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Rigidbody2D.velocity = Vector2.up * Speed;
    }
}
