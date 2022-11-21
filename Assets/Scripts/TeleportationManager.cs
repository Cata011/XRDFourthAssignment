using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TeleportationManager : MonoBehaviour
{
    [SerializeField]
    GameObject player_Rig;
    [SerializeField]
    GameObject destinationPointer;

    private bool is_aiming = false;
    private GameObject currentDestination;
    // Start is called before the first frame update

    void Start()
    {
        //currentDestination = Instantiate(destinationPointer, transform.position, Quaternion.identity);
    }
    public void SwitchAiming()
    {
        is_aiming = !is_aiming;
        if(!is_aiming)
        {
            destinationPointer.SetActive(false);
        }
    }
    private void CheckForDestination()
    {
        Ray ray = new Ray(transform.position, transform.rotation * Vector3.up);
        RaycastHit hit;
        bool b = Physics.Raycast(ray, out hit, 5, 1 << 6);
        
        if (b)
        {
            Debug.Log(hit.point);
            Debug.Log(hit.collider);
            Debug.Log(hit.transform);
            Debug.Log("RAY HIT TERRAIN");
            destinationPointer.transform.position = hit.point;
            destinationPointer.SetActive(true);
        }
    }
    public void Teleport()
    {
        if(is_aiming && destinationPointer.activeSelf)
        {
            Debug.Log("TELEPORT SUCCESSFULL");
            player_Rig.transform.position = destinationPointer.transform.position;
            destinationPointer.SetActive(false);
        }
    }

    void Update()
    {
        if(is_aiming)
        {
            CheckForDestination();
        }
    }
}
