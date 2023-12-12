using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class ObjectiveSystem : MonoBehaviour
{

    public GameObject WinScreen;


    public GameObject CurrentInteractable;
    public GameObject HealthBar;

    public GameObject[] ObjIcons;
    public GameObject[] ObjIconsComplete;

    public TMP_Text[] ObjectiveTexts;
    public bool[] ObjectivesCompleted;
    //cloth
    //door
    //electronics
    //water
    //phone
    public Interactable[] Doors;
    int DoorsClosed;
    int MaxDoors;

    public Interactable[] Electronics;
    int ElecOff;
    int MaxElec;
    public Camera WonCamera;

    public VideoPlayer videoplayer3;

    public GameObject bandana1;
    public GameObject bandana2;
    public GameObject door1;
    public GameObject door2;
    public GameObject electronics1;
    public GameObject electronics2;
    public GameObject water1;
    public GameObject water2;
    public GameObject phone1;
    public GameObject phone2;
    // Start is called before the first frame update
    void Start()
    {
        WonCamera.enabled = false;
        DoorsClosed = 0;
        ElecOff = 0;
        MaxDoors = Doors.Length;
        MaxElec = Electronics.Length;
        ObjectivesCompleted = new bool[ObjectiveTexts.Length];

        CurrentInteractable.SetActive(true);
        HealthBar.SetActive(true);

        bandana1.SetActive(true);
        door1.SetActive(true);
        electronics1.SetActive(true);
        water1.SetActive(true);
        phone1.SetActive(true);
        bandana2.SetActive(false);
        door2.SetActive(false);
        electronics2.SetActive(false);
        water2.SetActive(false);
        phone2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        ObjectiveTexts[1].text = "close all doors " + DoorsClosed.ToString() + "/" + MaxDoors.ToString();
        ObjectivesCompleted[1] = (DoorsClosed == MaxDoors);
        ObjectiveTexts[2].text = "turn off electronics " + ElecOff.ToString() + "/" + MaxElec.ToString();
        ObjectivesCompleted[2] = (ElecOff == MaxElec);
        for (int i = 0; i < ObjectiveTexts.Length; i++)
        {
            Color TargetColor = ObjectivesCompleted[i] ? Color.green : Color.white;
            ObjectiveTexts[i].color = Color.Lerp(ObjectiveTexts[i].color, TargetColor, 10 * Time.deltaTime);


        }
        
        for (int i = 0; i < ObjIcons.Length; i++)
        {
            bool completed = ObjectivesCompleted[i];
            ObjIcons[i].SetActive(!completed);
            ObjIconsComplete[i].SetActive(completed);


        }
        CheckDoors();
        CheckElec();
        CheckWon();
    }


    public void CompleteObjective(int i)
    {
        ObjectivesCompleted[i] = true;
        CheckWon();
    }

    void CheckWon()
    {
        bool won = true;
        for (int i = 0; i < ObjectiveTexts.Length; i++)
        {
            if (!ObjectivesCompleted[i])
                won = false;

        }
        if (won)
        {
            CurrentInteractable.SetActive(false);
            HealthBar.SetActive(false);
            WonCamera.enabled = true;
            GameManager.GameStarted = false;
            WinScreen.SetActive(true);
            videoplayer3.Play();
            videoplayer3.loopPointReached += OnVideo3Finished;
            gameObject.SetActive(false);
        }
    }

    void OnVideo3Finished(VideoPlayer vp)
    {
        // Video has finished playing, close the current panel and open the next one
        SceneManager.LoadScene(2);
    }
    void CheckDoors()
    {
        int d = 0;
        foreach (var door in Doors)
        {
            d += door.IsOpen ? 0 : 1;
        }
        DoorsClosed = d;
    }

    void CheckElec()
    {
        int d = 0;
        foreach (var elec in Electronics)
        {
            d += elec.TurnedOn ? 0 : 1;
        }
        ElecOff = d;
    }
}
