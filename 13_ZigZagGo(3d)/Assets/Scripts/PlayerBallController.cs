using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBallController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] ParticleSystem diamondParticles;
    [SerializeField] AudioClip diamindPickUpSound;

    Rigidbody ballRB;
    AudioSource playerAudioSourceref;
    bool gameStarted = false;
    bool gameOver = false;
    float timeElapsed = 0f;
    int intervals = 1;


    void Start()
    {
        ballRB = GetComponent<Rigidbody>();
        playerAudioSourceref = GetComponent<AudioSource>();
    }


    void Update()
    {
        MoveBall();
        CheckIfBallOnPlatform();
        // Debug.DrawRay(transform.position, Vector3.down, Color.black);
        RunClock();
    }

    private void CheckIfBallOnPlatform()
    {

        if (!Physics.Raycast(transform.position, Vector3.down, 10f))
        {
            ballRB.velocity = new Vector3(0, -moveSpeed, 0);
            gameOver = true;

            FindObjectOfType<FollowCamera>().gameOver = true;
            FindObjectOfType<PlatformSpawner>().gameOver = true;

            GameManager.instance.GameOver();
        }
    }

    private void MoveBall()
    {
        if (transform.position.y > 1.25)
        {
            Vector3 pos = new Vector3(transform.position.x, 1.004f, transform.position.z);
            transform.position = pos;
            Debug.Log("well it was called");
        }

        if (Input.GetMouseButtonDown(0) && !gameStarted)
        {
            gameStarted = true;
            ballRB.velocity = new Vector3(moveSpeed, 0, 0);

            FindAnyObjectByType<PlatformSpawner>().StartSpawnSequence();

            GameManager.instance.GameStart();
        }
        if (Input.GetMouseButtonDown(0) && !gameOver)
        {
            SwitchVelocityDirection();
        }
    }

    void SwitchVelocityDirection()
    {
        if (ballRB.velocity.x > 0)
        {
            ballRB.velocity = new Vector3(0, 0, moveSpeed);
        }
        else if (ballRB.velocity.z > 0)
        {
            ballRB.velocity = new Vector3(moveSpeed, 0, 0);
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Diamond")
        {
            playerAudioSourceref.PlayOneShot(diamindPickUpSound, 0.3f);
            ScoreManager.instance.UpdateDiamondCount();
            Destroy(other.gameObject);
            ParticleSystem part = Instantiate(diamondParticles, other.transform.position, Quaternion.identity);
            Destroy(part, 0.5f);
        }
    }

    void RunClock()
    {
        if (gameStarted && !gameOver)
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed > intervals * 15)
            {
                UIManager.instance.PlayMoreSpeedAnim();
                moveSpeed += 1f;
                intervals += 1;
            }
        }
    }
}
