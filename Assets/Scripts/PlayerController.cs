using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float movementSpeed = 3;
    Animator anim;
    Rigidbody rb;
    public PlayerController playerController;
    public Dead dead;
    public bool canMove;
    
    void Start()
    {
        canMove = true;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (canMove)
        {
            ControllPlayer();
        }
        else if (anim != null)
        {
            anim.enabled = false;
        }

        if (transform.position.x <= -10)
        {
            transform.position = new Vector3(-10, transform.position.y, transform.position.z);
        }

        else if (transform.position.x >= 10)
        {
            transform.position = new Vector3(10, transform.position.y, transform.position.z);
        }

        else if (transform.position.z <= -24)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -24);
        }

    }

    void ControllPlayer()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
            anim.SetInteger("Walk", 1);
        }
        else {
            anim.SetInteger("Walk", 0);
        }

        transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);

    }

   
}