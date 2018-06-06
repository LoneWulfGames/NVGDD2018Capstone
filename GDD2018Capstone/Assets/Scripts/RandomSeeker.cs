using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RandomSeeker : MonoBehaviour
{
    GameObject[] players;
    int seeker;

    void Start()
    {
        FindPlayers();
        PickSeeker();
        SeekerSetup();
    }

    void FindPlayers()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        
    }

    void PickSeeker()
    {
        seeker = Random.Range(0, players.Length);
    }

    void SeekerSetup()
    {
        foreach (var player in players)
        {
            player.GetComponent<PropManager>().SetHider();
        }
        players[seeker].GetComponent<PropManager>().SetSeeker();

    }

}
