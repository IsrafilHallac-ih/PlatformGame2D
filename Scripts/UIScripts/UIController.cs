using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class UIController : MonoBehaviour
{

    [SerializeField]
    Image heart1, heart2, heart3;

    [SerializeField]
    Sprite FullHeart,HalfHeart, EmptyHeart;

    [SerializeField]
    TMP_Text gemTxt;

    PlayerHealthController playerHealthController;
    LevelManager levelManager;

    public GameObject FadeScene;
    private void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();
        playerHealthController = FindObjectOfType<PlayerHealthController>();
    }
    

  public  void HealthUpdate()
    {
        switch (playerHealthController.validHealth)
        {
            case 6:
                heart1.sprite = FullHeart;
                heart2.sprite = FullHeart;
                heart3.sprite = FullHeart;
                break;

            case 5:
                heart1.sprite = FullHeart;
                heart2.sprite = FullHeart;
                heart3.sprite = HalfHeart;
                break;

            case 4:
                heart1.sprite = FullHeart;
                heart2.sprite = FullHeart;
                heart3.sprite = EmptyHeart;
                break;

            case 3:
             heart1.sprite = FullHeart;
             heart2.sprite = HalfHeart;
             heart3.sprite = EmptyHeart;
                break;

            case 2:
                heart1.sprite = FullHeart;
                heart2.sprite = EmptyHeart;
                heart3.sprite =EmptyHeart;
                break;

            case 1:
                heart1.sprite = HalfHeart;
                heart2.sprite = EmptyHeart;
                heart3.sprite = EmptyHeart;
                break;

            case 0:
                heart1.sprite = EmptyHeart;
                heart2.sprite = EmptyHeart;
                heart3.sprite = EmptyHeart;
                break;
        }
    }
  public void GemNumberUpdate()
    {
        gemTxt.text = levelManager.totalGem.ToString();
    }

    public void FadeScreneOpen()
    {
        FadeScene.GetComponent<CanvasGroup>().DOFade(1, .4f);
        
    }
}
