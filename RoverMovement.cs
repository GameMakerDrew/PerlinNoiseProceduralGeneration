using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoverMovement : MonoBehaviour
{
    public GameObject cameraHolder;

    public float xTurnStrength;
    public float yTurnStrength;

    public float speed;

    private void Start()
    {

    }
    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        

        //Update rover rotation based on user input
        transform.Rotate(new Vector3(-Input.GetAxis("Vertical") / yTurnStrength, 0, -Input.GetAxis("Horizontal") / xTurnStrength));

        //Update camera position
        cameraHolder.transform.position = transform.position;
        cameraHolder.transform.rotation = Quaternion.RotateTowards(Camera.main.transform.rotation, transform.rotation, 1f);

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
    }
}
