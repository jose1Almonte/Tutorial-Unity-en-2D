using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnMovements : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    private float Horizontal;
//
    private float Vertical;

    private float LastJump;
//

    private bool Grounded;
    private Animator Animator;
    public int Health = 5;
    private float LastShoot;
    private float Nohealth;

    public GameObject JohnSoulPrefab;
    public GameObject BulletPrefab;
    public float Speed;
    public float JumpForce;


    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        //

        Vertical = Input.GetAxisRaw("Vertical");

        //

        Animator.SetBool("running", Horizontal != 0.0f);

        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f,1.0f,1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f,1.0f,1.0f);

        Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);
        
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
        {
            Grounded = true;
        }
        else Grounded = false;

        if (Vertical > 0.0f && Grounded && Time.time > LastJump + 0.25f)
        {
            Jump();
            LastJump = Time.time;
        }

        if((Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Space)) && Time.time > LastShoot + 0.25f){
            Shoot();
            LastShoot = Time.time;
        }
            
        //

        if(Vertical < 0.0f) Debug.Log("agachao");

        Animator.SetBool("crouch", Vertical < 0.0f && Grounded && Horizontal == 0.0f);
        //

        if(Health == 0 && Time.time == Nohealth + 3.0f){
            
            Instantiate(JohnSoulPrefab, transform.position,Quaternion.identity);
            Health--;
        }
    }

    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    private void Shoot(){
        Vector3 direction;

        if (transform.localScale.x == 1.0f) direction = Vector3.right;
        else direction = Vector3.left;

        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal * Speed, Rigidbody2D.velocity.y);
    }

    public void Hit(){

        Health--;

        Debug.Log("Aquita: " + Health);
        
        Animator.SetBool("defeated", Health == 0);
        

        if (Health == 0) Nohealth = Time.time;
        


        //
        //if (Health == 0) Destroy(gameObject);
        //
    }


}
