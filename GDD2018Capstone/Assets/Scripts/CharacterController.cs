﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

//created by Ariel
//deals with player movement
//directly associated with camMouseLook script

public class CharacterController : NetworkBehaviour
{

    public float speed = 10.0f;

    public CharacterController player;

    public Camera cam;
    public CameraControlOther camControl;

	// Use this for initialization

	void Start ()
    {
        Cursor.lockState = CursorLockMode.Locked; //game cursor cannot be seen in game
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(!isLocalPlayer)
        {
            return;
        }

        float translation = Input.GetAxis("Vertical") * speed;
        float straffe = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;

        transform.Translate(straffe, 0, translation);

        if (Input.GetKeyDown("escape"))
            Cursor.lockState = CursorLockMode.None;
	}

    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.yellow;

        //prevent cursor usage
        Cursor.lockState = CursorLockMode.Locked;
        //setup character controller
        player = GetComponent<CharacterController>();
        cam = Camera.main;
        camControl = cam.GetComponent<CameraControlOther>();
        camControl.mob = this.gameObject;
        camControl.ResetCam();
    }
}
