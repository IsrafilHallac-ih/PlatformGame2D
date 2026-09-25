using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletMove;
    PlayerHealthController healthController;

    private void Awake()
    {
        healthController = FindObjectOfType<PlayerHealthController>();
    }

    private void Update()
    {
        transform.position += new Vector3(-bulletMove*transform.localScale.x* Time.deltaTime, 0f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            healthController.TakeDamage();
        }
        Destroy(gameObject);
    }

}
