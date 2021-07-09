using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwayTasks : MonoBehaviour
{
    //Activator for the entire task script
    public GameObject TutorialControllerHasBeenCompleted;
    //public Avatar JoeAvatar;
    public GameObject JoeAvatarRoom;
    public GameObject JoeAvatarHallway;

    public GameObject StartTasksButton;
    public GameObject triggerChecker;

    public GameObject BackWithJoe;
    public GameObject UserIsWithJoe; // Checker

    //public Animator JoeAnimation;
    public Animator JoeHallwayAnimator;

    public AudioSource PracticingMovingAudio;

    bool startPracticeMoving = false;
    bool handOnStartTasksButton = false;
    bool startTasksButtonCoordinatesHaveBeenStored = false;

    Vector3 startTasksButtonInitialPosition;
    Vector3 startTasksButtonPressedPosition;

    Vector3 JoeInitialPosition;
    Vector3 JoeHallwayPosition;
    float PressedOffset = 0.015f;

    //Task0 - Elements
    public GameObject Task0Objects;
    public GameObject TableOnTheLeft;
    public GameObject walkedToLeftTable;
    public AudioSource GoodJob3Audio;
    bool Task0InstructionsReleased = false;
    bool Task0HalfwayDone = false;
    bool Task0Done = false;
    public AudioSource PracticingGrabbingAudio;
    bool Task00InstructionsReleased = false;
    public GameObject ballsWithJoe; //Collider Checker
    bool Task00Done = false;

    // Task 1 - Elements
    bool startTask1 = false;
    bool Task1InstructionsReleased = false;
    public AudioSource Task1Audio;
    public AudioSource GoodJob1Audio;
    public AudioSource ExcellentAudio;
    public GameObject correctRighTurn; //ColliderDetector
    public GameObject bathroomHasBeenFound;//Collider Detector
    public GameObject Task1HasBeenCompleted; //Activated when Task 1 is Done
    bool task1rightturn = false;
    bool task1Done = false;

    //Task2 - Elements
    public AudioSource Task2Audio;
    bool Task2InstructionsReleased = false;
    public GameObject Task2Objects;
    bool task2rightturn = false;
    public GameObject computerSWithJoe;
    bool computerIsOnTable = false;
    public AudioSource LaptopOnTableAudio;
    bool userIsAwareOfPlacingComputerOnTable = false;
    public AudioSource ForgotComputerAudio;
    public GameObject computerIsOnTopTable;
    bool task2Done = false;
    public AudioSource Task3Audio;

    //-----------------------------------------     Task 0     -----------------------------------------
    void PracticeMoving() {
        PracticingMovingAudio.Play();

        //Switching Avatars 
        JoeAvatarRoom.SetActive(false);
        JoeAvatarHallway.SetActive(true);
        JoeHallwayAnimator = JoeHallwayAnimator.GetComponent<Animator>();
        //JoeAvatarRoom.transform.position = JoeHallwayPosition;
        //JoeAvatarRoom.transform.Rotate(0f, 130f, 0f);
        Task0Objects.SetActive(true);
        Task0InstructionsReleased = true;
    }

    void Task0Halfway() {
        GoodJob3Audio.Play();
        Debug.Log("Task 0 - Half");
        Task0HalfwayDone = true;
    }

    void Task0Completed() {
        Debug.Log("Task 0 has been Completed");
        Task0Done = true;
    }

    void PracticeGrabbing() {
        Debug.Log("Starting practice grabbing!");
        Task00InstructionsReleased = true;
        PracticingGrabbingAudio.Play();
    }

    void Task00Completed() {
        //DonePracticingAudio.Play();
        Task0Objects.SetActive(false);
        startTask1 = true;
    }

    //-----------------------------------------     Task 1     -----------------------------------------
    void Task1() {
        Task1InstructionsReleased = true;
        Task1Audio.Play();      
    }

    void Task1RightTurn() {
        GoodJob1Audio.Play();
        task1rightturn = true;
    }

    void Task1BathroomFound() {
        ExcellentAudio.Play();
        Task1HasBeenCompleted.SetActive(true);
        task1Done = true;
    }

    //-----------------------------------------     Task 2     -----------------------------------------
    void Task2() {
        Task2InstructionsReleased = true;
        Task2Objects.SetActive(true); //Laptop, Table
        Task2Audio.Play();  
    }

    void Task2RighTurn() {
        task2rightturn = true;
        GoodJob1Audio.Play();
    }

    void DidYouForgetComputer() {
        ForgotComputerAudio.Play();
    }

    void PutComputerOnTable() {
        LaptopOnTableAudio.Play();
        userIsAwareOfPlacingComputerOnTable = true;
    }

    void ComputerIsOnTheTable() {
        Debug.Log("Task2 has been completed");
        task2Done = true;
        Task3Audio.Play();
    }

    //-----------------------------------------     END OF INNER FUNCTIONS     -----------------------------------------

    void Start() {
        JoeInitialPosition = new Vector3(JoeAvatarRoom.transform.position.x, JoeAvatarRoom.transform.position.y, JoeAvatarRoom.transform.position.z);
        JoeHallwayPosition = new Vector3(-8.211f, 0.055f , 0.538f);
    }

    void OnTriggerEnter() {
        handOnStartTasksButton = true;
    }

    void OnTriggerExit(Collider other) {
        handOnStartTasksButton = false;
    }

    void storeStartTasksButtonCoordinates() {
        startTasksButtonInitialPosition = new Vector3(StartTasksButton.transform.position.x, StartTasksButton.transform.position.y, StartTasksButton.transform.position.z);
        startTasksButtonCoordinatesHaveBeenStored = true;

        //Pressed Coordinates
        startTasksButtonPressedPosition = new Vector3(startTasksButtonInitialPosition.x - PressedOffset, startTasksButtonInitialPosition.y, startTasksButtonInitialPosition.z);
    }


    void Update()
    {
        // Activating StartTasksButton
        if (TutorialControllerHasBeenCompleted.activeSelf == true) {
            StartTasksButton.SetActive(true);
        }

        //Storing Coordinates of StartTasksButton When it appears in the scene
        if(StartTasksButton.activeSelf == true && startTasksButtonCoordinatesHaveBeenStored == false) {
            storeStartTasksButtonCoordinates();
        }

        //Avatar IDLE when not talking
        if (!PracticingMovingAudio.isPlaying && !PracticingGrabbingAudio.isPlaying && !Task1Audio.isPlaying && !Task2Audio.isPlaying && !Task3Audio.isPlaying) {
            //JoeHallwayAnimator.Play("IDLE");
            JoeHallwayAnimator.SetBool("isTalking", false);
        }

        //Avatar performing Talking when any of the audios are playing
        if (PracticingMovingAudio.isPlaying || PracticingGrabbingAudio.isPlaying || Task1Audio.isPlaying || Task2Audio.isPlaying || Task3Audio.isPlaying) {
            //JoeHallwayAnimator.Play("TALKING");
            JoeHallwayAnimator.SetBool("isTalking", true);
        }

        //********************************************     Start Tasks    ***********************************************
        // Task 0.1 - Practicing Moving
        if (handOnStartTasksButton == true && triggerChecker.activeSelf == true && Task0InstructionsReleased == false) {
            Debug.Log("StartTasks has been pressed... Starting Tasks");
            StartTasksButton.transform.position = startTasksButtonPressedPosition;  
            //Activating collider for BackWithJoe
            BackWithJoe.SetActive(true);
            startPracticeMoving = true;
            PracticeMoving();
        }

        if (Task0InstructionsReleased == true && walkedToLeftTable.activeSelf == true && Task0HalfwayDone == false) {
            Task0Halfway();
        }

        if(Task0HalfwayDone == true && Task0Done == false) {
            if(UserIsWithJoe.activeSelf == true) {
                Debug.Log("Task0 has been completed");
                Task0Completed();
            }
        }

        //Task 0.2 - Practice Grabbing
        if(Task0Done == true && Task00InstructionsReleased == false) {
            PracticeGrabbing();
        }

        if (Task00InstructionsReleased == true && ballsWithJoe.activeSelf == true && Task00Done == false){
            Task00Completed();
        }

        //Task1 
        if(startTask1 == true && Task1InstructionsReleased == false) {
            Task1();
        }

        if(Task1InstructionsReleased == true && correctRighTurn.activeSelf == true && task1rightturn == false) {
            Task1RightTurn();
        }

        if(task1rightturn == true && bathroomHasBeenFound.activeSelf == true && task1Done == false) {
            Task1BathroomFound();
        }

        //Task2
        if(Task1HasBeenCompleted.activeSelf == true && UserIsWithJoe.activeSelf == true && Task2InstructionsReleased == false) {
            Task2();
        }

        if (Task2InstructionsReleased == true && correctRighTurn.activeSelf == true && task2rightturn == false) {
            Task2RighTurn();
        }

        if (Task2InstructionsReleased == true && task2rightturn == true && computerSWithJoe.activeSelf == false && UserIsWithJoe.activeSelf == true && !ForgotComputerAudio.isPlaying) {
            DidYouForgetComputer();
        }

        if(computerSWithJoe.activeSelf == true && computerIsOnTable == false && !userIsAwareOfPlacingComputerOnTable) {
            PutComputerOnTable();
        }

        if (computerIsOnTopTable.activeSelf == true && task2Done == false) {
            ComputerIsOnTheTable();
        }
    }
}
