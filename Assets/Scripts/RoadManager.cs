using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    public GameObject[] roadPrefabs; // Reference to your road prefabs
    public int numberOfRoads = 5; // Number of road prefabs to keep in the scene
    public float roadLength = 20f; // Length of each road prefab
    public float playerTriggerDistance = 5f; // Distance at which the player triggers road replacement

    private List<GameObject> roadInstances = new List<GameObject>();
    private Transform player;

    void Start()
    {
        player = Camera.main.transform; // Assuming the camera is the player or is a child of the player
        InstantiateRoads();
    }

    

    void InstantiateRoads()
    {
        for (int i = 0; i < numberOfRoads; i++)
        {
            roadLength = Random.Range(13.5f, 19);
            GameObject roadPrefab = roadPrefabs[Random.Range(0, roadPrefabs.Length)];
            GameObject road = Instantiate(roadPrefab, new Vector3(-30, -0.4f, i * roadLength), roadPrefab.transform.rotation, transform);
            roadInstances.Add(road);

        }
    }

    

    public void ReplaceRoad(Transform road)
    {
        roadLength = Random.Range(13.5f, 19);
        numberOfRoads++;
        // Destroy the oldest road
        GameObject oldRoad = roadInstances[0];
        road.position = new Vector3(0, 0, (numberOfRoads - 1) * roadLength);

    }
}
