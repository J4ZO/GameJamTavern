using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void RestartScene()
    {
        AudioManager.Instance.StopMusic();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SceneChange(int sceneIndex)
    {
        AudioManager.Instance.StopMusic();
        SceneManager.LoadScene(sceneIndex);
    }
}
