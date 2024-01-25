using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private FollowPlayer followPlayer;
    public Transform cam;
    public Transform player;
    private float maxpZ;
    private float maxcZ;
    private bool isFollow = true;
    


    public void Start()
    {
        isFollow = true;
        maxpZ = player.transform.position.z;
        maxcZ = Mathf.Max(maxcZ, cam.transform.position.z);
    }

    void Update()
    {

        if (player != null && isFollow == true)
        {
            
            transform.position = Vector3.Lerp(transform.position, new Vector3(0, 0, player.transform.position.z) + new Vector3(0, 11f, -7.5f), 0.2f);
            transform.rotation = Quaternion.Euler(new Vector3(50, 0, 0));

            if (player.transform.position.z < maxpZ-0.2f)
            {
                isFollow = false;
                Debug.Log("should work");
            }

            
        }
        if (player != null && player.transform.position.z > maxpZ)
        {
            isFollow = true;
            maxpZ = player.transform.position.z;
            Debug.Log("should work too");
        }
    }
}
