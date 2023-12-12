using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Menu2 : MonoBehaviour
{
    public GameObject Intro;
    public GameObject Menu;
    public GameObject Levels;
    public GameObject Level1;
    public GameObject Instruction;
    public GameObject InstructionComplete;

    public VideoPlayer videoplayer1;
    public VideoPlayer videoplayer2;
    // Start is called before the first frame update
    void Start()
    {


        Intro.SetActive(false);
        Menu.SetActive(false);
        Levels.SetActive(false);
        Level1.SetActive(false);
        Instruction.SetActive(false);
        InstructionComplete.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnVideo1Finished(VideoPlayer vp)
    {
        // Video has finished playing, close the current panel and open the next one
        OpenMenu();
    }
    void OnVideo2Finished(VideoPlayer vp)
    {
        // Video has finished playing, close the current panel and open the next one
        OpenInstruction();
    }
    public void StartLevel1()
    {
        SceneManager.LoadScene(1);
    }
    public void OpenMenu()
    {
        Intro.SetActive(false);
        Menu.SetActive(true);
        Levels.SetActive(false);
        Level1.SetActive(false);
        Instruction.SetActive(false);
        InstructionComplete.SetActive(false);
    }
    public void OpenLevels()
    {
        Intro.SetActive(false);
        Menu.SetActive(false);
        Levels.SetActive(true);
        Level1.SetActive(false);
        Instruction.SetActive(false);
        InstructionComplete.SetActive(false);
    }
    public void OpenInstruction()
    {
        Intro.SetActive(false);
        Menu.SetActive(false);
        Levels.SetActive(false);
        Level1.SetActive(false);
        Instruction.SetActive(true);
        InstructionComplete.SetActive(false);
    }
    public void OpenLevel1()
    {
        Intro.SetActive(false);
        Menu.SetActive(false);
        Levels.SetActive(false);
        Level1.SetActive(true);
        Instruction.SetActive(false);
        InstructionComplete.SetActive(false);
        videoplayer2.Play();
        videoplayer2.loopPointReached += OnVideo2Finished;
    }
    public void OpenInstructionComplete()
    {
        Intro.SetActive(false);
        Menu.SetActive(false);
        Levels.SetActive(false);
        Level1.SetActive(false);
        Instruction.SetActive(false);
        InstructionComplete.SetActive(true);
    }
}
