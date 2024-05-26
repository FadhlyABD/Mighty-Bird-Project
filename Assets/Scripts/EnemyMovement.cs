using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;
    public float deadZone = -20;
    public float health = 40;
    public Vector3 sizeChange;
    public LogicScript logic;
    public GameObject explosion;
    public Rigidbody2D rb;
    public BirdScript bird;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        bird = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdScript>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if (transform.position.x < deadZone)
        {
            Debug.Log("Enemy Deleted!");
            Destroy(gameObject);
        }
    }

    // If the bird collide gravity is active
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 3)
        {
            // You can use two ways to make it falls only after it collided
            // rb.gravityScale = 3;
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    public void TakeDamage(float damage)
    {
        // Enemy gets faster when shot
        health -= damage;
        moveSpeed += 5;

        if(health <= 0)
        {
            Debug.Log("Enemy Killed!");
            Destroy(gameObject);
            logic.addScore(1);

            // When the player has reached level 5:
            // we will gradually increase the bird size
            bird.transform.localScale += sizeChange;
            // moveSpeed += 0.5f;

            // Make the explosion VFX with particle
            GameObject particle = Instantiate(explosion, transform.position, transform.rotation);
            Destroy(particle, 0.75f);
        }
    }
}
