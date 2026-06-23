using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
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
        StartMusicBattle();
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
        AudioManager.Instance.StopMusic();
        pauseUI.SetActive(!pauseUI.activeSelf);

        AudioManager.Instance.PlayMusic(pauseUI.activeSelf ? 2 : 1, 0.8f);
        Time.timeScale = Mathf.Approximately(Time.timeScale, 1) ? 0 : 1;
    }

    
    private IEnumerator WaitToWin()
    {
        AudioManager.Instance.StopMusic();
        yield return new WaitForSeconds(1f);
        AudioManager.Instance.PlayMusic(0,0.8f);
        Time.timeScale = 0;
        winUI.SetActive(true);
       
    }

    
    private IEnumerator WaitToLose()
    {
        AudioManager.Instance.StopMusic();
        yield return new WaitForSeconds(1f);
        AudioManager.Instance.PlayMusic(1,0.8f);
        Time.timeScale = 0;
        Debug.Log("game over ui appeared");
        gameOverUI.SetActive(true);
        
    }

    private void StartMusicBattle()
    {
        AudioManager.Instance.PlayClip(1);
        AudioManager.Instance.PlayMusic(1,0.8f);
    }
}
