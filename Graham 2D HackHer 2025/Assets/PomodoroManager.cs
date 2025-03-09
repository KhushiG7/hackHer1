using UnityEngine;
using UnityEngine.UI;
using TMPro;  // Importing the TextMeshPro namespace
 
public class PomodoroManager : MonoBehaviour
{
    // UI elements
    public TMP_Text timerText;    // To display the time left
    public Button startStopButton; // Start/Stop button
    public Button pauseButton; // Pause button
    public ProgressBar progressBar;
 
    // Timer settings
    private float workTime = 25f * 60f; // 25 minutes in seconds
    private float breakTime = 5f * 60f; // 5 minutes break in seconds
    private float currentTime;
    private bool isWorking = true; // Start with a work session
    private bool isTimerRunning = false;
    private bool isPaused = false;
 
    public void Start()
    {
        // Initialize the timer with work time
        currentTime = workTime;
 
        // Set button listeners
        //startStopButton.onClick.AddListener(ToggleTimer);
        //pauseButton.onClick.AddListener(PauseTimer);
 
        // Initially disable the Pause button
        pauseButton.interactable = false;
 
        // Update the timer display
        timerText.text = FormatTime(currentTime);
    }
 
    public void Update()
    {
        // If the timer is running and not paused, update the timer
        if (isTimerRunning && !isPaused)
        {
            currentTime -= Time.deltaTime;  // Decrease time based on frame rate
 
            // Update timer text
            timerText.text = FormatTime(currentTime);
 
            // Switch between work and break sessions when time runs out
            if (currentTime <= 0)
            {
                if (isWorking)
                {
                    // Switch to break time
                    isWorking = false;
                    currentTime = breakTime;
                    progressBar.AddPB(20);
                    Debug.Log("Switching to Break Time");
                }
                else
                {
                    // Switch to work time
                    isWorking = true;
                    currentTime = workTime;
                    progressBar.AddPB(-10);
                    Debug.Log("Switching to Work Time");
                }
            }
        }
    }
 
    // Toggle the timer between Start and Stop
    public void ToggleTimer()
    {
        if (isTimerRunning && isPaused == false)
        {
            StopTimer();
        }
        else
        {
            StartTimer();
        }
    }
 
    // Start the timer
    public void StartTimer()
    {
        isTimerRunning = true; // Set timer running to true
        isPaused = false; // Ensure it's not paused
        //startStopButton.GetComponentInChildren<TMP_Text>().text = "Stop";  // Change button text to Stop
        pauseButton.interactable = true; // Enable pause button
        Debug.Log("Timer Started");
    }
 
    // Pause the timer
    public void PauseTimer()
    {
        isPaused = true;  // Pause the timer
        pauseButton.interactable = false; // Disable pause button
        //startStopButton.GetComponentInChildren<TMP_Text>().text = "Start";  // Change button text to Start
        Debug.Log("Timer Paused");
    }
 
    // Stop the timer and reset it to the initial state
    public void StopTimer()
    {
        isTimerRunning = false; // Stop the timer
        isPaused = false;  // Make sure the timer is not paused
        currentTime = workTime; // Reset timer to work time
        timerText.text = FormatTime(currentTime);  // Update display
        //startStopButton.GetComponentInChildren<TMP_Text>().text = "Start";  // Change button text to Start
        pauseButton.interactable = false;  // Disable pause button
        Debug.Log("Timer Stopped and Reset");
    }
 
    // Format time to display as minutes:seconds
    string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}