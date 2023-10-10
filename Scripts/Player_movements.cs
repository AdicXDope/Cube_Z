using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movements : MonoBehaviour
{ 
    Rigidbody rb;
    [SerializeField] float movementSpeed = 6f;
    [SerializeField]float jumpForce = 5f;
    [SerializeField]Transform groundCheck;
    [SerializeField]LayerMask ground;
    public AudioSource jumpSound;
    
    
    // Start is called before the first frame update
    void Start()
    {
       rb= GetComponent<Rigidbody>();
       
     
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput=Input.GetAxis("Horizontal");
        float verticalInput=Input.GetAxis("Vertical");

        rb.velocity=new Vector3(horizontalInput*movementSpeed,rb.velocity.y,verticalInput*movementSpeed);
     


        if(Input.GetButton("Jump")&& IsGrounded())
        {
            Jump();
        } 
        
    }
    void Jump()
    {
        rb.velocity = new Vector3( rb.velocity.x,jumpForce,rb.velocity.z);
        jumpSound.Play();

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("head"))
        {
            Destroy(collision.transform.parent.gameObject);
            Jump();
        }
    }
    
    bool IsGrounded()
    {
       return Physics.CheckSphere(groundCheck.position, 0.1f,ground);

    }
    

}