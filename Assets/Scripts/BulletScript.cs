using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    private Vector2 Direction;

    public float Speed;
    public AudioClip Sound;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Rigidbody2D.velocity = Direction * Speed;
    }

    public void SetDirection(Vector2 direction){
        
        Direction = direction;

    }

    public void DestroyBullet(){
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        JohnMovements john = collision.GetComponent<JohnMovements>();
        GruntScript grunt = collision.GetComponent<GruntScript>();

        if (john != null) john.Hit();
        if (grunt != null) grunt.Hit();
        DestroyBullet();
    }

// Esto se queda comentado porque le dimos a la palomita de "is Triger" de la bala. (Se usa el método de arriba)
    // private void OnCollisionEnter2D(Collision2D collision) {
    //     JohnMovements john = collision.collider.GetComponent<JohnMovements>();
    //     GruntScript grunt = collision.collider.GetComponent<GruntScript>();

    //     if (john != null) john.Hit();
    //     if (grunt != null) grunt.Hit();
    //     DestroyBullet();
    // }
}
