using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCollisions : MonoBehaviour
{
    public PlayersController playerController;

    private void Start()
    {
        playerController = GetComponentInParent<PlayersController>();
    }

    void OnCollisionStay()
    {
        //Debug.Log("OnCollisionStay was called");
        playerController.isGrounded = true;
    }
}
