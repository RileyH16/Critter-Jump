using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarScript : MonoBehaviour
{
    AudioSource hornHonk;
    public float speedX = 50.0f;
    private Rigidbody playerBody;
    private float rightBound = 70.0f;
    private float leftBound = -70.0f;
    public float waitTime = 2f;
    private bool gameOver = false;
    private bool startCoroutine = false;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent <AudioSource> ();
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

        if (gameOver == true && startCoroutine == false)
        {

            StartCoroutine(Wait());
            startCoroutine = true;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        // When collide with player, flatten it!
        if (other.gameObject.tag == "Player")
        {
            
            Vector3 scale = other.gameObject.transform.localScale;
            other.gameObject.transform.localScale = new Vector3(scale.x, scale.y * 0.1f, scale.z);
            gameOver = true;
            PlayerController moveScript;
            moveScript = other.gameObject.GetComponent<PlayerController>();
            moveScript.canMove = false;
            GameObject.Find("Canvas").GetComponent<ScoreManager>().SavePlayer();
            
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(2);
    }

}
