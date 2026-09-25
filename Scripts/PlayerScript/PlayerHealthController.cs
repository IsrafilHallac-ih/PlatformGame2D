using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public int maxHealth,validHealth;
    UIController UIController;

    [SerializeField]
    GameObject DeathEffect;

    public float invincibilityDuration;
    float invincibilityCounter;

    SpriteRenderer spriteRenderer;
    PlayerController playerController;
    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        UIController = FindObjectOfType<UIController>();
    }
    void Start()
    {
        validHealth = maxHealth;
    }

    private void Update()
    {
        invincibilityCounter -= Time.deltaTime;
        if (invincibilityCounter<=0)
        {
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1f);
        }
    }

   

     public void TakeDamage()
    {
        if (invincibilityCounter<=0)
        {
            validHealth--;
            if (validHealth <= 0)
            {
                validHealth = 0;
                gameObject.SetActive(false);
                Instantiate(DeathEffect, transform.position, transform.rotation);
                SoundController.instance.SoundEffects(2);
            }
            else
            {
                invincibilityCounter = invincibilityDuration;
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.5f);
                playerController.Recoil();
                SoundController.instance.SoundEffects(1);
            }
            UIController.HealthUpdate();
        }
        
    }

    public void LifeUpdateFNC() //CAN ARTTIR FONKSÝYONU
    {
        validHealth++;
        if (validHealth>=maxHealth)
        {
            validHealth = maxHealth;
        }
        UIController.HealthUpdate();
    }
    
}
