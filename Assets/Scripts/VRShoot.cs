using Oculus.Interaction;
using Oculus.Interaction.Grab;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRShoot : MonoBehaviour
{

    /*public SimpleShoot SimpleShoot;

    public OVRInput.Button shootbutton;

    private OVRGrabbable _grabbable;

    private AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        _grabbable = GetComponent<OVRGrabbable>();
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_grabbable.isGrabbed && OVRInput.GetDown(shootbutton, _grabbable.grabbedBy.GetController()))
        {
            SimpleShoot.StartShoot();
            _audioSource.Play();
        }
    }*/

    public SimpleShoot SimpleShoot;

    private AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "Collider")
        {
            SimpleShoot.StartShoot();
        }
        
    }
}
