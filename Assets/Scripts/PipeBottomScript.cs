using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeBottomScript : MonoBehaviour
{
    [SerializeField] private AudioSource slideSFX;
    private float timer;
    public float health = 40;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            slideSFX.Play();
            transform.position = transform.position + (Vector3.down * 5);
            // Destroy(gameObject);
        }
    }

}
