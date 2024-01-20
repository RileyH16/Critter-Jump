using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

  
    public Transform player;




    void Update()
    {

        if (player != null)
        {
            transform.position = player.transform.position + new Vector3(0, 11f, -7.5f);
            transform.rotation = Quaternion.Euler(new Vector3(50, 0, 0));
        }

    }
}
