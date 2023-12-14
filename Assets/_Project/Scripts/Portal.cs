using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    // Start is called before the first frame update
    ParticleSystem particle;
    [SerializeField] AudioSource audioSource;
    [SerializeField] string sceneName;
    public FadeScreen fadeScreen;
    public bool useSound;
    void Start()
    {
        particle = GetComponent<ParticleSystem>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenPortal()
    {
        particle.Play();
        audioSource.Play();

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            StartCoroutine(ChangeSceneRoutine(sceneName));
        }
    }
    IEnumerator ChangeSceneRoutine(string nameScene)
    {
        fadeScreen.FadeOut();
        yield return new WaitForSeconds(fadeScreen.fadeDuration);
        SceneManager.LoadScene(nameScene);
    }
}
