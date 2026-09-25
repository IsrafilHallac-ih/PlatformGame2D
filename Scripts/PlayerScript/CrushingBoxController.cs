using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrushingBoxController : MonoBehaviour
{

    [SerializeField]
    GameObject deadthEffect;

    PlayerController playerController;
    public float cherryChance;
    public GameObject cherryObject;

    private void Awake()
    {
        playerController =FindObjectOfType<PlayerController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Frog"))
        {
            collision.transform.parent.gameObject.SetActive(false);
            Instantiate(deadthEffect, transform.position, transform.rotation);
            

            playerController.Jump2XFNC();

            float releaseInterval = Random.Range(0f, 100f);

            SoundController.instance.SoundEffects(0);
            if (releaseInterval<=cherryChance)
            {
                 Instantiate(cherryObject,collision.transform.position,collision.transform.rotation);
            }
        }
    }

    
}
