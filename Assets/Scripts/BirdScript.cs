using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    [SerializeField] private AudioSource jumpSFX;
    public Rigidbody2D myRigidBody;
    public GameObject fire;
    public ShootingScript shoot;
    public LogicScript logic;
    public float jumpPower;
    public float bulletSpeed;
    public bool birdIsAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        shoot = GameObject.FindGameObjectWithTag("Shoot").GetComponent<ShootingScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(birdIsAlive == true)
        {
            // To shoot the bullet
            if(Input.GetKeyDown(KeyCode.Space) == true)
            {
                shoot.ShootBullet();
            }

            // To flap the bird
            if (Input.GetMouseButtonDown(0))
		    {
                jumpSFX.Play();
				myRigidBody.velocity = Vector2.up * jumpPower;

			    // RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			    // if(hit.collider == null)
		    }

            // Fire appears when bird moving up
            if (myRigidBody.velocity.y > 0)
            {
                fire.SetActive(true);
            }
            else
            {
                fire.SetActive(false);            
            }

            // Bird going out from the screen
            if(transform.position.y > 8 || transform.position.y < -8)
            {
                logic.gameOverScene();
                birdIsAlive = false;
            }
        }
        else
        {
            // Bird will rotate after it collided (gameOver)
            transform.Rotate(new Vector3(0, 0, 1));
            fire.SetActive(false);
        }
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Bird hit the " + collision.gameObject.name + ", You Lose!");
        logic.gameOverScene();
        birdIsAlive = false;
    }

}
