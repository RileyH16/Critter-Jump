using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{

    public float speedX = 1.0f;
    private Rigidbody playerBody;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speedX * Time.deltaTime, 0.0f, 0.0f);
    }

    void OnTriggerEnter(Collider other)
    {
        // When collide with player, flatten it!
        if (other.gameObject.tag == "Player")
        {
            Vector3 scale = other.gameObject.transform.localScale;
            other.gameObject.transform.localScale = new Vector3(scale.x, scale.y * 0.1f, scale.z);
            other.gameObject.SendMessage("GameOver");
        }
    }
}
