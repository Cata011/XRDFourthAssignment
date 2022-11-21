using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class SwitchLight : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject light;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Lightbulb"))
        {
            Instantiate(light, gameObject.transform.position, gameObject.transform.rotation);
        }
    }
}