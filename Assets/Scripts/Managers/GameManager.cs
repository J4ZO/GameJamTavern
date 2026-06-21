using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    [Header("References")]
    [SerializeField] private SpawnSystem spawnSystem;
    [SerializeField] private Boss boss;
    [SerializeField] private Player player;

    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject winUI;
    [SerializeField] private GameObject pauseUI;
    
    
    [Header("Actions")]
    [SerializeField] private InputActionReference pauseAction;
    
    void Start()
    {
        Time.timeScale = 1;
        spawnSystem.Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (boss.IsDead)
        {
            winUI.SetActive(true);
            Time.timeScale = 0;
        }

        if (player.IsDead)
        {
            gameOverUI.SetActive(true);
            Time.timeScale = 0;
        }

        if (pauseAction.action.WasPressedThisFrame())
        {
            PauseToggle();
        }
    }


    private void PauseToggle()
    {
        pauseUI.SetActive(!pauseUI.activeSelf);
        Time.timeScale = Mathf.Approximately(Time.timeScale, 1) ? 0 : 1;
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SceneChange(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
