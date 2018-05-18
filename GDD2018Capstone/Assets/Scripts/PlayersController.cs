﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

//created by Ariel
//deals with player movement
//directly associated with camMouseLook script

public class PlayersController : NetworkBehaviour
{

    public float speed;

    public bool isSprinting;

    public bool cursorLocked;

    public Camera cam;
    public CameraControlOther camControl;

    // Use this for initialization

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //game cursor cannot be seen in game
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        if (isSprinting == false)
            speed = 8.0f;

        float translation = Input.GetAxis("Vertical") * speed;
        float straffe = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;

        transform.Translate(straffe, 0, translation);

        /*float x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);*/

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 10f;
            isSprinting = true;
        }

        if (!Input.GetKey(KeyCode.LeftShift))
            isSprinting = false;

        if (Input.GetKeyDown("escape") && (cursorLocked == true))
        {
            Cursor.lockState = CursorLockMode.None;
            cursorLocked = false;
        }

        if (Input.GetKeyDown("escape") && (cursorLocked == false))
        {
            Cursor.lockState = CursorLockMode.Locked;
            cursorLocked = true;
        }
    }

    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.yellow;

        //prevent cursor usage
        Cursor.lockState = CursorLockMode.Locked;
        //setup character controller
        cam = Camera.main;
        camControl = cam.GetComponent<CameraControlOther>();
        camControl.mob = this.gameObject;
        camControl.ResetCam();
    }
}
