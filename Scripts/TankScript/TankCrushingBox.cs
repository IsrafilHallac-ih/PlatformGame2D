using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCrushingBox : MonoBehaviour
{
    PlayerController playerController;
    TankController tankController;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
        tankController = FindObjectOfType<TankController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")&& playerController.transform.position.y>transform.position.y)

        {
            
            playerController.Jump2XFNC();
            tankController.ReceiveBlowFNC();
            gameObject.SetActive(false);
        }
    }
}
