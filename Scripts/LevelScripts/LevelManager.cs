using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public static LevelManager instance;
    public int totalGem;

    PlayerController playerController;
    UIController uýController;

    public string SceneName;

    private void Awake()
    {
        instance = this;
        playerController = FindObjectOfType<PlayerController>();
        uýController = FindObjectOfType<UIController>();
    }
    
    public void SceneFinish()
    {
        StartCoroutine(SceneFinishRoutine());
    }

    IEnumerator SceneFinishRoutine()
    {
        yield return new WaitForSeconds(.1f);
        playerController.MoveStop=false;

        yield return new WaitForSeconds(1f);
        uýController.FadeScreneOpen();

        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneName);

    }
}
