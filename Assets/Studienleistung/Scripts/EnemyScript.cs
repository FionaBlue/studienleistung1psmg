using UnityEngine;
using System.Collections;
using System;

public class EnemyScript : MonoBehaviour {

    Rigidbody rigidBody;

    public GameObject goLeft;
    public GameObject goRight;

    
    
    string direction = "left";

    float left;
    float right;

   

    void Start()
    {
        left = goLeft.transform.position.z;
        right = goRight.transform.position.z;
        
        rigidBody = GetComponent<Rigidbody>();
    }


    //moves the enemy rigidbody to the left and right
    // when enemy reaches the sides he turns around
    void Update()
    {
       
        rigidBody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
        
            if (direction == "left")
            {
                
                if (transform.position.z < left)
                {
                    StartCoroutine(TurnAround("right"));
                    rigidBody.velocity = Vector3.zero;
                }
                else {
                   
                    rigidBody.velocity = new Vector3(0, 0, -2);

                }
            }
            if (direction == "right")
            {
                
                if (transform.position.z > right)
                {
                    StartCoroutine(TurnAround("left"));
                    rigidBody.velocity = Vector3.zero;
                }
                else {
                    
                    rigidBody.velocity = new Vector3(0, 0, 2);

                }
            }

        }

    //turns the enemy rigidbody to the other sides
    IEnumerator TurnAround(string dir)
    {
        direction = "none";
        transform.rotation *= Quaternion.Euler(0, 180f, 0);
        yield return new WaitForSeconds(1);
        direction = dir;
    }
}
