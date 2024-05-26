using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // To instantiate with rotated object (because of the source)
    public void ShootBullet()
    {
        Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.Euler(0, 180, 0));
    }
}
