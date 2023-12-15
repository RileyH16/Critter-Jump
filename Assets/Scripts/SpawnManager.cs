using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SpawnManager : MonoBehaviour
{
    private float startDelay = 0f;
    private float spawnInterval = 1.0f;
    public GameObject[] carPrefabs;
    public Transform rightSpawn;
    public Transform leftSpawn;
    

    private List<GameObject> Enemy;

    // Start is called before the first frame update
    public void Start()
    {
        Invoke("SpawnObstacle", startDelay);
        Enemy = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    void SpawnObstacle()
    {
        spawnInterval = Random.Range(0.75f, 1.0f);

        int randomCar = Random.Range(0, carPrefabs.Length);

        Instantiate(carPrefabs[randomCar], transform.position, carPrefabs[randomCar].transform.rotation);
        Instantiate(carPrefabs[randomCar], transform.position, Quaternion.Euler(0, -90, 0));

        Invoke("SpawnObstacle", spawnInterval);

       
    }

}
