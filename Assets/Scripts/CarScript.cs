using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarScript : MonoBehaviour
{

    public float speedX = 50.0f;
    private Rigidbody playerBody;
    private float rightBound = 40.0f;
    private float leftBound = -40.0f;
    public float waitTime = 1.5f;
    private bool gameOver = false;

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

        if (gameOver == true)
        {

            Debug.Log("NEXT SCENE");
            StartCoroutine(Wait());
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
            
            gameOver = true;
            
        }
    }

    IEnumerator Wait()
    {           
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
