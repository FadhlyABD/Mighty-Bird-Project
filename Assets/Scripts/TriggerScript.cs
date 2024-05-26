using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    public PipeBottomScript bottom;
    public int trigger;

    // Start is called before the first frame update
    void Start()
    {
        bottom = GameObject.FindGameObjectWithTag("Bottom").GetComponent<PipeBottomScript>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        // If the object collide is exactly the bullet 
        if(other.gameObject.layer == 6)
        {
            bottom.transform.position += Vector3.down * 10;
            Debug.Log("Collide ! Trigger =" + trigger);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        
        Debug.Log("Trigger Exit!");
    }
}
