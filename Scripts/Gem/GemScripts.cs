using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemScripts : MonoBehaviour
{
    [SerializeField]
    bool isGem,isCherry;

    bool gathered;

    [SerializeField]
    GameObject totalEffect;

    LevelManager levelManager;
    UIController uIController;
    PlayerHealthController playerHealth;

    private void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();
        uIController = FindObjectOfType<UIController>();
        playerHealth = FindObjectOfType<PlayerHealthController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
           if (collision.CompareTag("Player") && !gathered)
        { 
        
            if (isGem) 
            {

                levelManager.totalGem++;
                gathered = true;
                Destroy(gameObject);

                uIController.GemNumberUpdate();

                Instantiate(totalEffect, transform.position, transform.rotation);
                SoundController.instance.MixSoundEffects(7);
            }
            if (isCherry)
            {
                if (playerHealth.validHealth!=playerHealth.maxHealth)
                {
                    
                    gathered = true;
                    Destroy(gameObject);
                    playerHealth.LifeUpdateFNC();

                    Instantiate(totalEffect, transform.position, transform.rotation);
                    SoundController.instance.SoundEffects(4);
                }
            }
            
        }
    }
        
    
}
