using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollowsPlayer : MonoBehaviour
{
    private NavMeshAgent enemy;

   [SerializeField] public Transform player;
    [SerializeField] public GameObject deathScreen;
    [SerializeField] public GameObject winScreen;
    private float spawnDistance = 1.5f;
    [SerializeField] int health = 100;

   private void Awake()
   {
       enemy = GetComponent<NavMeshAgent>();
   }

   public void Update()
   {
       enemy.destination = player.position;
   }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name + "AAAAAAAAAAAAAAAAA");
        if(collision.gameObject.name == "OculusInteractionSampleRig")
        {
            transform.gameObject.SetActive(false);
            deathScreen.SetActive(true);
            deathScreen.transform.position = player.transform.position + new Vector3(player.transform.forward.x, player.transform.forward.y + 1, player.transform.forward.z).normalized * spawnDistance;
            deathScreen.transform.LookAt(new Vector3(player.transform.position.x, deathScreen.transform.position.y, player.transform.position.z));
            deathScreen.transform.forward *= -1;
        }
        if (collision.gameObject.name == "45ACP Bullet_Head(Clone)")
        {
            health -= 25;
            if(health == 0)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        transform.gameObject.SetActive(false);
        winScreen?.SetActive(true);
        winScreen.transform.position = player.transform.position + new Vector3(player.transform.forward.x, player.transform.forward.y + 1, player.transform.forward.z).normalized * spawnDistance;
        winScreen.transform.LookAt(new Vector3(player.transform.position.x, winScreen.transform.position.y, player.transform.position.z));
        winScreen.transform.forward *= -1;
    }
}
