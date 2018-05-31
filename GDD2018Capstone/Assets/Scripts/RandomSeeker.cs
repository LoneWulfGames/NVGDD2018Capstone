using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSeeker : MonoBehaviour
{
    GameObject[] players;



    private void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");

        int seeker = Random.Range(0, players.Length);
        players[seeker].GetComponent<RandomSeeker>().SeekHide();
    }

    public void SeekHide()
    {
        
    }
}
