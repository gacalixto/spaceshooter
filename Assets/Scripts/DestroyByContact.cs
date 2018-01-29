using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {
    public GameObject explosion;
    public GameObject playerExplosion;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")//this if will verify if the other collider is the boundary collider
            return;//then it will return nothing 
        Instantiate(explosion, transform.position, transform.rotation);
        if(other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
        }
        
        Destroy(other.gameObject);
        Destroy(gameObject);
    }

}
