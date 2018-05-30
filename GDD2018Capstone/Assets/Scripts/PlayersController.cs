using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class PlayersController : NetworkBehaviour
{

    public float speed;
    public float walkingSpeed;
    public float jumpForce = 2.0f;

    [SerializeField]
    private float sprintingSpeed;

    public bool isSprinting;
    public bool cursorLocked;
    public bool isSeeker = false;
    public bool isGrounded;

    public Vector3 jump;
    public Rigidbody rb;
    public Camera cam;
    public CameraControlOther camControl;

    void Start()
    {
        rb = GetComponentInChildren<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked; //game cursor cannot be seen in game

        sprintingSpeed = walkingSpeed * 1.5f;

        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        #region Jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
        #endregion

        #region Movement
        float translation = Input.GetAxis("Vertical") * speed;
        float straffe = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;

        transform.Translate(straffe, 0, translation);
        #endregion

        #region old movement
        /*float x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);*/
        #endregion

        #region Sprinting
        if (isSprinting == false)
        {
            speed = walkingSpeed;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = sprintingSpeed;
            isSprinting = true;
        }

        if (!Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = false;
        }
        #endregion

        #region Cursor LockState
        if (Input.GetKeyDown("escape") && (Cursor.lockState == CursorLockMode.Locked))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        else if (Input.GetKeyDown("escape") && (Cursor.lockState == CursorLockMode.None))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        #endregion
    }

    public override void OnStartLocalPlayer()
    {
        //prevent cursor usage
        Cursor.lockState = CursorLockMode.Locked;
        //setup character controller
        cam = Camera.main;
        camControl = cam.GetComponent<CameraControlOther>();
        camControl.mob = this.gameObject;
        camControl.ResetCam();
    }
}
