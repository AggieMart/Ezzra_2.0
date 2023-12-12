using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{
    public Image HealthImage;

    public float health;
    public static bool GameStarted = false;
    public Camera IntroCam, PlayerCam;
    public float IntroLength = 2;
    public GameObject UI;
    public GameObject LoseScreen;

    public GameObject CurrentInteractable;
    public GameObject HealthBar;

    public VideoPlayer videoplayer;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        CurrentInteractable.SetActive(true);
        HealthBar.SetActive(true);
        LoseScreen.SetActive(false);
        PlayerCam.enabled = false;
        IntroCam.enabled = true;
        health = 1;
        UI.SetActive(false);
        FindObjectOfType<CharacterController>().enabled = false;
        yield return new WaitForSeconds(IntroLength);
        StartGame();
        Cursor.lockState = CursorLockMode.Locked;
    }


   
    // Update is called once per frame
    void Update()
    {
        if(GameStarted)
        {
            if (health > 0)
            {
                health -= Time.deltaTime * 0.003f;
                HealthImage.fillAmount = health;
            }


            if (health <= 0)
            {
                GameOver();
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                Restart();
            }
        }

    }

    public void StartGame()
    {
        GameStarted = true;
        IntroCam.enabled = false;
        PlayerCam.enabled = true; 
        UI.SetActive(true);
        FindObjectOfType<CharacterController>().enabled = true;
    }
    void GameOver()
    {
        CurrentInteractable.SetActive(false);
        HealthBar.SetActive(false);
        GameStarted = false;
        print("gameover");
        PlayerCam.enabled = false;
        IntroCam.enabled = true;
        
        videoplayer.Play();
        videoplayer.loopPointReached += OnVideoFinished;

    }
    void OnVideoFinished(VideoPlayer vp)
    {
        // Video has finished playing, close the current panel and open the next one
        LoseScreen.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
