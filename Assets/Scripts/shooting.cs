using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public GameObject tiro;

    public float forca;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        GameObject tiroI = Instantiate(tiro, transform.position, transform.rotation);
        tiroI.GetComponent<Rigidbody2D>().AddForce(transform.right * forca);
    }
}
