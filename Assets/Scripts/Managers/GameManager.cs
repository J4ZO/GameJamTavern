using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    [Header("References")]
    [SerializeField] private SpawnSystem spawnSystem;
    [SerializeField] private Boss boss;
    [SerializeField] private Player player;

    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject winUI;
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private Image bossHealthBar;
    [SerializeField] private Image playerHealthBar;
    
    
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
        if (boss.IsDead && !player.IsDead)
        {
            bossHealthBar.fillAmount = 0f;
            StartCoroutine(WaitToWin());
        }

        if (player.IsDead)
        {
            playerHealthBar.fillAmount = 0f;
            Debug.Log("Player is Dead");
            StartCoroutine(WaitToLose());
        }

        if (pauseAction.action.WasPressedThisFrame() && !player.IsDead && !boss.IsDead)
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


    private IEnumerator WaitToWin()
    {
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0;
        winUI.SetActive(true);
        
    }

    
    private IEnumerator WaitToLose()
    {
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0;
        Debug.Log("game over ui appeared");
        gameOverUI.SetActive(true);
    }
}
