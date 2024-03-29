﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float movementSpeed = 3;
    Animator anim;
    Rigidbody rb;
    public PlayerController playerController;
    public GameOver dead;
    public bool canMove;
    private float horizontal, vertical;
    public GameObject myCamera;

    public AudioSource splatSound;
    public AudioSource hornSound;
    


    void Start()
    {
        splatSound.volume = AudioManager.Instance.sfxVolume;
        hornSound.volume = AudioManager.Instance.sfxVolume;
        myCamera = Camera.main.gameObject;
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

        else if (transform.position.x >= 8)
        {
            transform.position = new Vector3(8, transform.position.y, transform.position.z);
        }

        else if (transform.position.z <= myCamera.transform.position.z + 2.5f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, myCamera.transform.position.z + 2.5f);
        }
        
       
        
       
    }

    void ControllPlayer()
    {

        Vector3 movement = new Vector3(horizontal, 0.0f, vertical);

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
            anim.SetInteger("Walk", 1);
        }
        else
        {
            anim.SetInteger("Walk", 0);
        }

        transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);

    }

    public void OnMove(InputValue value)
    {
        horizontal = value.Get<Vector2>().x;
        vertical = value.Get<Vector2>().y;
    }

    public void MoveInput(Vector2 input)
    {

        horizontal = input.normalized.x;
        vertical = input.normalized.y;
    }


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            splatSound.Play();
        }

       
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Horn")
        {
            hornSound.Play();
        }
    }
}