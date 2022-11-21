using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ManageBattery : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.Find("WhiteLight").GetComponent<Light>().intensity = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Battery"))
        {
            gameObject.transform.Find("WhiteLight").GetComponent<Light>().intensity = 1;
            Destroy(collision.gameObject);
        }
    }
    
}
