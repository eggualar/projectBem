using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyRotation : MonoBehaviour
{
    [SerializeField]
    float rSpd;

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
        {
            transform.localEulerAngles = new Vector3(0, 0, 135);
        }
        else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
        {
            transform.localEulerAngles = new Vector3(0, 0, 45);
        }
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
        {
            transform.localEulerAngles = new Vector3(0, 0, -135);
        }
        else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
        {
            transform.localEulerAngles = new Vector3(0, 0, -45);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.localEulerAngles = new Vector3(0, 0, 180);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.localEulerAngles = new Vector3(0, 0, -90);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            transform.localEulerAngles = new Vector3(0, 0, 90);
        }
    }
}
