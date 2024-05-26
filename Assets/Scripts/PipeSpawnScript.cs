using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject Pipe1;
    public GameObject Pipe2;
    public GameObject Pipe4;
    public GameObject Enemy;
    public LogicScript logic;
    public float spawnRate1;
    public float spawnRate2;
    private float timer = 0;
    public float heightOffset1;
    public float heightOffset2;
    public float thridLvlOffset;
    public float thirdLvlAdder = 1;
    // public float speedBooster = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        SpawnPipe(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(logic.level != 3)
        {
            if (timer < spawnRate1)
            {
                timer = timer + Time.deltaTime;
            }
            else
            {
                SpawnPipe(0);
                timer = 0;
            }
        }
        if(logic.level == 3)
        {
            if (timer < spawnRate2)
            {
                timer = timer + Time.deltaTime;
            }
            else
            {
                SpawnPipe(thridLvlOffset);
                timer = 0;

                // To spawn pipe ascending and descending
                thridLvlOffset += thirdLvlAdder;
                if(thridLvlOffset == 7)
                {
                    thirdLvlAdder = -1;
                }
                else if(thridLvlOffset == -6)
                {
                    thirdLvlAdder = 1;
                }
                
            }
        }
    }

    void SpawnPipe(float i)
    {
        float lowestPoint1 = transform.position.y - heightOffset1;
        float highestPoint1 = transform.position.y + heightOffset1;
        float lowestPoint2 = transform.position.y - heightOffset2;
        float highestPoint2 = transform.position.y + heightOffset2;

        // Spawn the obstacle according to the level
        if (logic.level == 1)
        {
            Instantiate(Pipe1, new Vector3(transform.position.x, Random.Range(lowestPoint1, highestPoint1), 0), transform.rotation);
        }
        if (logic.level == 2)
        {
            Instantiate(Pipe2, new Vector3(transform.position.x, Random.Range(lowestPoint2, highestPoint2), 0), transform.rotation);
        }
        if (logic.level == 3)
        {
            Instantiate(Pipe1, new Vector3(transform.position.x, i, 0), transform.rotation);
        }
        if (logic.level == 4)
        {
            Instantiate(Pipe4, new Vector3(transform.position.x, Random.Range(lowestPoint1 + 1, highestPoint1 - 1), 0), transform.rotation);
        }
        if (logic.level == 5)
        {
            Instantiate(Enemy, new Vector3(transform.position.x, Random.Range(lowestPoint1, highestPoint1), 0), Quaternion.Euler(0, 180, 0));
            // Enemy.moveSpeed = Enemy.moveSpeed + speedBooster;
        }
    }
}
