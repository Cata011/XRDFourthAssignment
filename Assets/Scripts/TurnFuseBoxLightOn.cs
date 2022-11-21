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

public class TurnFuseBoxLightOn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject light;
    public GameObject bulb;
    private int numberOfSwitchesUsed = 0;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(numberOfSwitchesUsed == 4) Instantiate(light, bulb.transform.position, bulb.transform.rotation);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("righthand")) //TODO: change in hands to right hands
        {
            if (gameObject.transform.Find("Switch"))
            {
                numberOfSwitchesUsed++;
            }
        }
    }
}