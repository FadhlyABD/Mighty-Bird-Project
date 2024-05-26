using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPipeScript : MonoBehaviour
{
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.up * moveSpeed) * Time.deltaTime;

        if (transform.position.y > 4.5)
        {
            moveSpeed *= -1;
        }
        if (transform.position.y < -4)
        {
            moveSpeed *= -1;
        }
    }
        
}
