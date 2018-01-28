using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Boundary
{
    public float zMin, zMax, xMin, xMax;


}

public class PlayerController : MonoBehaviour {
    public float speed;//variable that controls the speed in which the ship moves
    public Boundary boundary;//instance of the class Boundary
    public float tilt;//variable for controlling the tilt of the ship
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");//both variables used to control the ship
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);//a vector 3 to control the movement in the x and y axis

        GetComponent<Rigidbody>().velocity = movement * speed;//here the velocity component from rigidbody gets assigned values
        GetComponent<Rigidbody>().position = new Vector3(Mathf.Clamp(GetComponent<Rigidbody>().position.x,boundary.xMin, boundary.xMax),0.0f,Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax));
        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x*-tilt) ;
    }

}
