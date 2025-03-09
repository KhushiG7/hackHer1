using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ToDoListManager : MonoBehaviour
{
    public TMP_InputField taskInputField;
    public Button addTaskButton;
    public GameObject taskPrefab;
    public Transform taskListContainer;
    public TextMeshProUGUI warningMessage;
    public ProgressBar progressBar;

    private List<GameObject> tasks = new List<GameObject>();
    private const int maxTasks = 5;

    void Start()
    {
        addTaskButton.onClick.AddListener(AddTask);
        warningMessage.gameObject.SetActive(false); // Hide warning initially
    }

    void AddTask()
    {
        if (tasks.Count >= maxTasks)
        {
            warningMessage.gameObject.SetActive(true); // Show warning
            return;
        }

        if (!string.IsNullOrWhiteSpace(taskInputField.text))
        {
            GameObject newTask = Instantiate(taskPrefab, taskListContainer);
            newTask.transform.Find("TaskText").GetComponent<TextMeshProUGUI>().text = taskInputField.text;
            
            // Set up the remove button
            newTask.transform.Find("CompleteButton").GetComponent<Button>().onClick.AddListener(() => RemoveTask(newTask));

            tasks.Add(newTask);
            taskInputField.text = ""; // Clear input field
            warningMessage.gameObject.SetActive(false); // Hide warning

            progressBar.AddPB(20);
        }
    }

    void RemoveTask(GameObject task)
    {
        tasks.Remove(task);
        Destroy(task);

        if (tasks.Count < maxTasks)
        {
            warningMessage.gameObject.SetActive(false); // Hide warning if tasks drop below limit
        }

        progressBar.AddPB(-5);
    }
}
