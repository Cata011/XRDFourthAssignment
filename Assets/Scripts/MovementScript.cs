using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    [SerializeField]
    float movementSpeed = 5.0f;
    [SerializeField]
    GameObject playerRig;
    RigidbodyConstraints originalConstraints;
    // Start is called before the first frame update
    void Start()
    {
        originalConstraints = playerRig.GetComponent<Rigidbody>().constraints;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void Movement()
    {
        playerRig.transform.position += Camera.main.transform.forward * Time.deltaTime * movementSpeed;
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Collider")
        {
            playerRig.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Collider")
        {
            playerRig.GetComponent<Rigidbody>().constraints = originalConstraints;
            Movement();
        }
    }



}
