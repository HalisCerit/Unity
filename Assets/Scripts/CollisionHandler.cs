using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 2f;
    [SerializeField] AudioClip CrashSound;
    [SerializeField] AudioClip FinisingSound;
    private void OnCollisionEnter(Collision collision)
    {

        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Friendly");
                break;

            case "Finish":
                Debug.Log("Finish");
                FinishingLevelSequence();
                break;


            case "Fuel":
                Debug.Log("Fuel");
                break;
            default:
                CrashSequence();
                break;
        }

    }
    private void SoundPlayer(AudioClip clip) 
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().PlayOneShot(clip);
        GetComponent<AudioSource>().loop = false;

    }
    private void FinishingLevelSequence()
    {
        SoundPlayer(FinisingSound);
        GetComponent<Movement>().enabled = false;
        Invoke("NextLevel", levelLoadDelay);
    }

    void CrashSequence()
    {
        SoundPlayer(CrashSound);
        GetComponent<Movement>().enabled = false;
        Invoke("RestartLevel", levelLoadDelay);
    }
    void RestartLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    void NextLevel()
    {
        
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex > SceneManager.sceneCountInBuildSettings - 1)
        { SceneManager.LoadScene(0); }
        else
        { SceneManager.LoadScene(nextSceneIndex); }

    }

}



