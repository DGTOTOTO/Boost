using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] AudioClip successAudio;
    [SerializeField] AudioClip crashAudio;
    [SerializeField] ParticleSystem successParticle;
    [SerializeField] ParticleSystem crashParticle;
    bool isTransition = false;
    AudioSource audiosc;

    void Start()
    {
        audiosc = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision other)
    {
        if (!isTransition)
        {
            switch (other.gameObject.tag)
            {
                case "Fuel":
                    break;
                case "Obstacle":
                    StartCrashSequence();
                    break;
                case "Finish":
                    StartNextSequence();
                    break;
                default:
                    break;
            }
        }

    }

    void StartCrashSequence()
    {
        isTransition = true;
        crashParticle.Play();
        audiosc.Stop();
        audiosc.PlayOneShot(crashAudio);
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", 1f);
    }

    void StartNextSequence()
    {
        isTransition = true;
        successParticle.Play();
        audiosc.Stop();
        audiosc.PlayOneShot(successAudio);
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", 1f);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }

}
