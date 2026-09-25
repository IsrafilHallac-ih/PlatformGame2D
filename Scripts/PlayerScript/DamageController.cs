using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    PlayerHealthController healthController;
    private void Awake()
    {
        healthController = Object.FindObjectOfType<PlayerHealthController>();
    }
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Player")
        {
            healthController.TakeDamage();
        }
    }
}
