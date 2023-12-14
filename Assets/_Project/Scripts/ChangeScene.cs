using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public FadeScreen fadeScreen;
    // Start is called before the first frame update
 
    public void SceneChange(string nameScene)
    {
        StartCoroutine(ChangeSceneRoutine(nameScene));  
    }

    IEnumerator ChangeSceneRoutine(string nameScene)
    {
        fadeScreen.FadeOut();
        yield return new WaitForSeconds(fadeScreen.fadeDuration);
        SceneManager.LoadScene(nameScene);
    }
    public void OutGame()
    {
        Application.Quit();
    }
}
