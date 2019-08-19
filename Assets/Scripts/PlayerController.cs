using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed, hSpeed;
    bool hitFloor;

    // Start is called before the first frame update
    void Start()
    {
        // Nothing!
        hitFloor = false;
    }

    // Update is called once per frame
    void Update()
    {

        bool respawnKey = Input.GetKey(KeyCode.Space);
        hSpeed = Input.GetAxis("Horizontal");

        // Move player left and right on keyPress (hSpeed)
        transform.Translate(Vector3.right * Time.deltaTime * speed * hSpeed);


        // If hitfloor
        if (hitFloor)
        {
            // Invoke moveForward();
            moveForward();
        }

        if (respawnKey)
        {
            respawn();
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        string name = collision.gameObject.name;

        // If collides with floor
        if (name.Contains("Floor"))
        {
            // Set hitfloor to true
            hitFloor = true;
        }

        // Hit obstacles (or cube)
        if (name.Contains("Cube"))
        {
            // Respawn
            respawn();
        }
    }

    // Move player forward constantly
    void moveForward()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    // Set to origin position
    void respawn()
    {
        Debug.Log("RESPAWN");

        transform.position = new Vector3(0, 2, 0);
        transform.rotation = new Quaternion(0, 0, 0, 0);
    }
}
