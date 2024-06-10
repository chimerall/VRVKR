using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System.Linq;

public class TaskScript : MonoBehaviour
{

    public Button button1;
    public Button button2;
    public Button button3;
    public TextMeshProUGUI taskText; // Reference to the UI Text element
    public Button taskButton; // Reference to the Button
    public Button fixIssueButton; // Reference to the "Fix Issue" Button
    public Button powerOffButton; // Reference to the "Power Off" Button
    public Button calibrateButton; // Reference to the "Calibrate" Button
    public Button replacePowerBlockButton; // Reference to the "Replace Power Block" Button
    public Button nextTaskButton; // Reference to the "Next Task" Button
    public TMP_Dropdown speedDropdown; // Reference to the Dropdown menu
    public Button applyChangesButton; // Reference to the "Apply Changes" button

    private List<string> tasks = new List<string>(); // List to hold task descriptions
    private int currentTaskIndex = -1; // Index of the current task
    private List<bool> completedTasks = new List<bool>(); // List to track completed tasks
    private bool powerButtonOn = true; // Flag to track the state of the power button
    public GameObject canvasPrintingStation; // Reference to the CanvasPrintingStation

    // Property to access the list of completed tasks
    public List<bool> CompletedTasks
    {
        get { return completedTasks; }
    }

    private void Start()
    {
        // Initially hide the task text and buttons
        taskText.gameObject.SetActive(false);
        fixIssueButton.gameObject.SetActive(false);
        powerOffButton.gameObject.SetActive(false);
        calibrateButton.gameObject.SetActive(false);
        replacePowerBlockButton.gameObject.SetActive(false);
        speedDropdown.gameObject.SetActive(false);
        applyChangesButton.gameObject.SetActive(false);

        // Add listeners to buttons
        button1.onClick.AddListener(AddTasksForButton1);
        button2.onClick.AddListener(AddTasksForButton2);
        button3.onClick.AddListener(AddTasksForButton3);

        // Initialize the completed tasks list
        for (int i = 0; i < tasks.Count; i++)
        {
            completedTasks.Add(false);
        }

        // Add a listener to the button to call the ShowTask method when clicked
        taskButton.onClick.AddListener(ShowNextTask);

        // Add a listener to the fix issue button to call the FixIssue method when clicked
        fixIssueButton.onClick.AddListener(FixIssue);

        // Add a listener to the replace power block button to call the ReplacePowerBlock method when clicked
        replacePowerBlockButton.onClick.AddListener(ReplacePowerBlock);

        // Add a listener to the calibrate button to call the Calibrate method when clicked
        calibrateButton.onClick.AddListener(Calibrate);

        // Add a listener to the next task button to call the ButtonShowNextTask method when clicked
        nextTaskButton.onClick.AddListener(ButtonShowNextTask);

        // Add a listener to the power off button to handle the power button click
        powerOffButton.onClick.AddListener(TogglePowerButton);

        // Add a listener to the apply changes button to handle the changes
        applyChangesButton.onClick.AddListener(ApplySpeedChanges);
        
    }

    public void AddTasksForButton1()
    {
        // Add tasks to the 3d list
        tasks.Add("Устраните засор печатающей головки ");
        tasks.Add("Выполните замену блока питания ");
        tasks.Add("Выполните повторную калибровку платформы ");
        tasks.Add("Измените управляющие параметры скорости печати ");

        // Additional operations or logic specific to button 1 if needed
    }

    public void AddTasksForButton2()
    {
       // Add tasks to the Laser list
        tasks.Add("Выполните повторную калибровку положения");
        tasks.Add("Измените параметры резки в управляющем ПО");
        tasks.Add("Устраните загрязнения в направляющих и рельсах");
        tasks.Add("Выполните замену блока питания");

        // Additional operations or logic specific to button 2 if needed
    }

    public void AddTasksForButton3()
    {
        // Add tasks to the Fres list
        tasks.Add("Выполните проверку состояния механических компонентов");
        tasks.Add("Выполните замену фрезы");
        tasks.Add("Выполните повторную калибровку положения");
        tasks.Add("Выполните замену блока питания");

        // Additional operations or logic specific to button 3 if needed
    }

    // Method to show the next task
    public void ShowNextTask()
    {
        
        List<int> incompleteTaskIndices = completedTasks
            .Select((completed, index) => new { completed, index })
            .Where(x => !x.completed)
            .Select(x => x.index)
            .ToList();

        if (incompleteTaskIndices.Count == 0)
        {
            taskText.text = "Все задания выполнены!";
            taskText.gameObject.SetActive(true);
            return;
        }

        // Get a random index for the next task from the list of incomplete tasks
        int randomIndex = incompleteTaskIndices[Random.Range(0, incompleteTaskIndices.Count)];

        currentTaskIndex = randomIndex;

        // Update the task text with the selected task
        taskText.text = tasks[currentTaskIndex];
        taskText.gameObject.SetActive(true);

        // Show or hide buttons based on the selected task
        if (taskText.text.Contains("Выполните замену блока питания"))
        {
            Debug.Log("Текущее задание: " + taskText.text);
            powerOffButton.gameObject.SetActive(true);
            replacePowerBlockButton.gameObject.SetActive(true);
        }
        else if (taskText.text.Contains("Выполните повторную калибровку платформы"))
        {
            calibrateButton.gameObject.SetActive(true);
            powerOffButton.gameObject.SetActive(false);
            replacePowerBlockButton.gameObject.SetActive(false);
        }
        else if (taskText.text.Contains ("Измените управляющие параметры скорости печати"))
        {
            speedDropdown.gameObject.SetActive(true);
            applyChangesButton.gameObject.SetActive(true);
            powerOffButton.gameObject.SetActive(false);
            calibrateButton.gameObject.SetActive(false);
            replacePowerBlockButton.gameObject.SetActive(false);
        }
        else
        {
            powerOffButton.gameObject.SetActive(false);
            calibrateButton.gameObject.SetActive(false);
            replacePowerBlockButton.gameObject.SetActive(false);
            speedDropdown.gameObject.SetActive(false);
            applyChangesButton.gameObject.SetActive(false);
        }
    }

    // Method to handle the "Next Task" button click
    public void ButtonShowNextTask()
    {
        ShowNextTask();
        fixIssueButton.gameObject.SetActive(false);
        calibrateButton.gameObject.SetActive(false);
    }

    // Method to fix the issue
    public void FixIssue()
    {
        // Update the task text with strikethrough for the current task
        taskText.text = "<s>" + tasks[currentTaskIndex] + "</s>";

        // Update the completed tasks list
        completedTasks[currentTaskIndex] = true;

        // Show the next task
        ShowNextTask();

        // Hide the fix issue button
        fixIssueButton.gameObject.SetActive(false);
    }

    // Method to replace the power block
    public void ReplacePowerBlock()
    {
        if (powerButtonOn)
        {
            // Power button is on, cannot replace the power block yet
            taskText.text = "Выключите питание, чтобы заменить блок питания";
        }
        else
        {
            // Power button is off, replace the power block
            taskText.text = "Замените блок питания и включите питание";
            replacePowerBlockButton.gameObject.SetActive(false); // Hide the replace power block button
        }
    }

    // Method to handle calibrating
    public void Calibrate()
    {
        // Update the task text with strikethrough for the current task
        taskText.text = "<s>" + tasks[currentTaskIndex] + "</s>";

        // Update the completed tasks list
        completedTasks[currentTaskIndex] = true;

        // Show the next task
        ShowNextTask();

        // Hide the calibrate button
        calibrateButton.gameObject.SetActive(false);
    }

    // Method to handle power button toggle
    private void TogglePowerButton()
    {
        powerButtonOn = !powerButtonOn;

        if (powerButtonOn)
        {
            // Power is ON
            powerOffButton.GetComponentInChildren<TextMeshProUGUI>().text = "Power ON";
        }
        else
        {
            // Power is OFF
            powerOffButton.GetComponentInChildren<TextMeshProUGUI>().text = "Power OFF";
        }

        // If the current task is to replace the power block and power is back on
        if (powerButtonOn && taskText.text.Contains("Замените блок питания и включите питание"))
        {
            taskText.text = "<s>" + tasks[currentTaskIndex] + "</s>";

            // Update the completed tasks list
            completedTasks[currentTaskIndex] = true;

            // Show the next task
            ShowNextTask();
        }
    }

    // Method to apply speed changes
    private void ApplySpeedChanges()
    {
        if (speedDropdown.options[speedDropdown.value].text == "Medium" && tasks[currentTaskIndex] == "Измените управляющие параметры скорости печати")
        {
            // Mark the task as completed
            taskText.text = "<s>" + tasks[currentTaskIndex] + "</s>";
            completedTasks[currentTaskIndex] = true;
            ShowNextTask();

            // Hide the entire menu
            canvasPrintingStation.SetActive(false);
        }
    }
} 
