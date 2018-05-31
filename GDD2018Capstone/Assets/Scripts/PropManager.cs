using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropManager : MonoBehaviour {

    public GameObject player;
    public GameObject clonePlayer;

	public void Swap(GameObject prop) {
        if (player.activeInHierarchy)
        {
            player.SetActive(false);
        }
        else
        {
            Destroy(clonePlayer);
        }
        GameObject newClonePlayer;
        newClonePlayer = Instantiate(prop, transform.position, Quaternion.identity, transform) as GameObject;
        clonePlayer = newClonePlayer;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                print("hit: " + hit.transform.name);

                //make an if statment to check if the hit is on another player and the player firing is a seeker
                //then make the object disabled but keep the camera.
                if (hit.transform.CompareTag("Prop"))
                {
                    Swap(hit.transform.GetComponent<PropHolder>().propModel);
                }
            }
        }
    }
}
