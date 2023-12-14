using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public FadeScreen fadeScreen;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(fadeScreen.fadeDuration);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Resume()
    { 
        Time.timeScale = 1;
    }
    public void Restart(string nameScene)
    {
        Time.timeScale = 1;
        StartCoroutine(ChangeSceneRoutine(nameScene));
        
    }
    public void Surrender(string nameScene)
    {
        Time.timeScale = 1;
        StartCoroutine(ChangeSceneRoutine(nameScene));
        
    }
    IEnumerator ChangeSceneRoutine(string nameScene)
    {
        fadeScreen.FadeOut();
        yield return new WaitForSeconds(fadeScreen.fadeDuration);
        SceneManager.LoadScene(nameScene);
    }
}
