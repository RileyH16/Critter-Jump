using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMover : MonoBehaviour
{

    private RoadManager roadManager;


    private void Awake()
    {
        roadManager = GameObject.Find("Roads").GetComponent<RoadManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            roadManager.ReplaceRoad(transform);

        if (other.CompareTag("Player"))
            ScoreManager.instance.AddPoint();
    }
}
