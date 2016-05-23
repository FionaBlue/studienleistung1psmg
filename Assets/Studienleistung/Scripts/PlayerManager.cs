using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour {

    public int m_healthPoint;

    public GameObject explosion;
    public GameObject gameOverPanel;
    public GameObject winPanel;

    public AudioClip winSound;
    public AudioClip hitSound;
    new AudioSource audio;

    private PlayerInputManager m_inputManager;

    private bool collisionWithEnemyPossible;

    //initiates the health points of the player
    public int HealthPoint{
        get {
            return m_healthPoint;
        }

        set {
            m_healthPoint = value;
        }
    }

    //decreases the speed of the player when being hit
    private void decreaseSpeedIfHit(){
       

        if (m_healthPoint == 3)
        {
            m_inputManager.speedBoost -= 7;
        }
        if (m_healthPoint == 2)
        {
            m_inputManager.speedBoost -= 7;
        }
        if (m_healthPoint == 1)
        {
            m_inputManager.speedBoost -= 3;
        }
    }



    //Sets up all important variables of the Player
        public void Start()
    {
        audio = GetComponent<AudioSource>();
        collisionWithEnemyPossible = true;
        
        m_healthPoint = 4;

        m_inputManager = GetComponent<PlayerInputManager>();
        m_inputManager.Start();

    }

    //handles all collisions with bombs, enemies and the flag
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Bombe")
        {
            GameObject.Instantiate(explosion, GetComponent<Transform>().position, new Quaternion());
            collision.collider.enabled = false;
            audio.PlayOneShot(hitSound);
            m_healthPoint--;
            decreaseSpeedIfHit();
            if (m_healthPoint < 1)
            {
                gameOverPanel.SetActive(true);
                Destroy(gameObject);
            }
        }

        if (collision.collider.tag == "Enemy")
        {
            if (collisionWithEnemyPossible)
            {
                m_healthPoint--;
                decreaseSpeedIfHit();
                if (m_healthPoint < 1)
                {
                    gameOverPanel.SetActive(true);
                    Destroy(gameObject);
                }
                collisionWithEnemyPossible = false;
                StartCoroutine(WaitForNextCollision());
            }
            
        }

        if (collision.collider.tag == "WinZone")
        {
            audio.PlayOneShot(winSound);
            StartCoroutine(waitForSoundToFinish());
                       
        }

    }

    //lets winSound finish before setting up the winPanel
    IEnumerator waitForSoundToFinish()
    {
        yield return new WaitForSeconds(1);
        winPanel.SetActive(true);
        Destroy(gameObject);
    }


    //wait for a few seconds, so the collision with enemy doesn't 
    // hit the player multiple times
    IEnumerator WaitForNextCollision()
    {
        yield return new WaitForSeconds(1);
        collisionWithEnemyPossible = true;
    }

}
