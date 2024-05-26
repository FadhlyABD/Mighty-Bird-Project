using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float moveSpeed;
    public float deadZone = 20;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.right * moveSpeed) * Time.deltaTime;

        if (transform.position.x > deadZone)
        {
            Debug.Log("Bullet Deleted!");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        // To get component of object that shooted by the bullet
        PipeBottomScript bottom = other.GetComponent<PipeBottomScript>();
        EnemyMovement enemy = other.GetComponent<EnemyMovement>();

        if(bottom != null)
        {
            bottom.TakeDamage(20);
        }
        if(enemy != null)
        {
            enemy.TakeDamage(20);
            enemy.moveSpeed += 0.5f;
        }
        // So that the bullet do not disappear when collide with middle pipe
        if(other.gameObject.layer != 7)
        {
            Debug.Log("Bullet Deleted!");
            Destroy(gameObject);
            
        }
    }

}
