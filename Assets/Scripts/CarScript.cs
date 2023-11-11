using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{

    public float speedX = 50.0f;
    private Rigidbody playerBody;
    private float rightBound = 40.0f;
    private float leftBound = -40.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speedX);

        if (transform.position.x > rightBound && gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }

        else if (transform.position.x < leftBound && gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        // When collide with player, flatten it!
        if (other.gameObject.tag == "Player")
        {
            Vector3 scale = other.gameObject.transform.localScale;
            other.gameObject.transform.localScale = new Vector3(scale.x, scale.y * 0.1f, scale.z);
            Debug.Log("GameOver");
        }
    }
}
