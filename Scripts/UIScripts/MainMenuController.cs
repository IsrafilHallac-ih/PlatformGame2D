using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;


public class MainMenuController : MonoBehaviour
{
    public string sceneName;
    public GameObject ýmgObject;
    public GameObject startPlay, exitPlay;
    public GameObject fadeScreen;
    private void Start()
    {
        StartCoroutine(OpenRoutine());
    }

     IEnumerator OpenRoutine()
    {
        yield return new WaitForSeconds(.5f);
        ýmgObject.GetComponent<CanvasGroup>().DOFade(1f, 0.5f);

        yield return new WaitForSeconds(.4f);
        startPlay.GetComponent<CanvasGroup>().DOGoto(1f);
        startPlay.GetComponent<RectTransform>().DOScale(1f, .5f).SetEase(Ease.OutBack);

        yield return new WaitForSeconds(.6f);
        exitPlay.GetComponent<CanvasGroup>().DOGoto(1f);
        exitPlay.GetComponent<RectTransform>().DOScale(1f, .5f).SetEase(Ease.OutBack);
    }

    public void GamePlay()
    {
        StartCoroutine(gameOpenRoutine());
    }
    public void GameExit()
    {
        Application.Quit();
    }

    IEnumerator gameOpenRoutine()
    {
        yield return new WaitForSeconds(.1f);
        fadeScreen.GetComponent<CanvasGroup>().DOFade(1, 1f);

        yield return new WaitForSeconds(1f);
        

        SceneManager.LoadScene(sceneName);
    }
}
