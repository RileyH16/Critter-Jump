using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private FollowPlayer followPlayer;
    public Transform cam;
    public Transform player;
    public float maxpZ;
    public float maxcZ;
    private bool isFollow = true;
    


    public void Start()
    {
        isFollow = followPlayer;
    }

    void FixedUpdate()
    {

        if (player != null)
        {
            maxpZ = Mathf.Max(maxpZ, player.transform.position.z);
            maxcZ = Mathf.Max(maxcZ, cam.transform.position.z);


            transform.position = player.transform.position + new Vector3(0, 11f, -7.5f);
            transform.rotation = Quaternion.Euler(new Vector3(50, 0, 0));

            if (player.transform.position.z < maxpZ)
            {
                isFollow = false;
                Debug.Log("should work");
            }

            
        }

    }
}
