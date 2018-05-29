using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekerDelay : MonoBehaviour
{
    //public SetSeeker setSeeker;
    public GameObject blindfold;

    public float seekerStartDelay;

    private void Start()
    {
        //blindfold = GameObject.FindGameObjectWithTag("Blindfold");

        StartCoroutine(WaitForSeconds());
    }

    IEnumerator WaitForSeconds()
    {
        blindfold.SetActive(true);
        yield return new WaitForSeconds(seekerStartDelay);
        blindfold.SetActive(false);
    }
}
