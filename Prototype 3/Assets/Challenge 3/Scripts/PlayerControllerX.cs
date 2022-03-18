using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver;
    private float speed = 1f;
    public float floatForce;
    private float gravityModifier = 2.5f;
    private Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;


    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>(); //@missing get component
        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * speed * Time.deltaTime, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < 14)
        {
            // While space is pressed and player is low enough, float up
            if (Input.GetKey(KeyCode.Space) && !gameOver)
            {
                playerRb.AddForce(Vector3.up * floatForce);
            }
        }
        
        if(transform.position.y <= 0)
        {
            // jumps up if balloon hits the ground
            playerRb.AddForce(Vector3.up * 20);
            if(!playerAudio.isPlaying && transform.position.y <= -0.5)
            {
                playerAudio.PlayOneShot(moneySound, 1.0f);
            }
            
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

        }

    }

}
