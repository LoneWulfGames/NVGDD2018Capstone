using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropManager : MonoBehaviour {

    public GameObject player;
    public GameObject clonePlayer;
    public bool isHider;
    public bool found;
    

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
               if(hit.transform.CompareTag("Prop") && isHider == true)
                {
                    Swap(hit.transform.GetComponent<PropHolder>().propModel);
                }

               if(hit.transform.CompareTag("Prop") && isHider == false)
                {
                    if (hit.transform.GetComponent<PropManager>().isHider == true)
                    {
                        hit.transform.GetComponent<PropManager>().IsFound();
                    }
                }

                
                if (hit.transform.CompareTag("Prop"))
                {
                    Swap(hit.transform.GetComponent<PropHolder>().propModel);
                }
            }
        }
    }

    void IsFound()
    {
        found = true;
        Destroy(clonePlayer);

    }

    public void SetHider()
    {
        isHider = true;
    }

    public void SetSeeker()
    {
        isHider = false;
    }
}
