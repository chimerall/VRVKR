using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class EndWorkScript : MonoBehaviour
{
    public Button endWorkButton; // Reference to the "End Work" Button
    public TextMeshProUGUI resultText; // Reference to the UI Text element to display the result
    public TaskScript taskScript; // Reference to the TaskScript component to access task completion status
    public Timer timerScript; // Reference to the Timer component to access the current time

    // Method to handle the "End Work" button click
    public void EndWork()
    {
        // Calculate the number of completed tasks
        int completedTasksCount = 0;
        foreach (bool taskCompleted in taskScript.CompletedTasks)
        {
            if (taskCompleted)
            {
                completedTasksCount++;
            }
        }

        // Get the current time from the timer script
        float currentTime = timerScript.timeStart;

        // Display the result
        TimeSpan workTime = TimeSpan.FromSeconds(currentTime);
        resultText.text = "Выполнено заданий: " + completedTasksCount + "\n" +
                          "Время работы: " + workTime.ToString(@"hh\:mm\:ss");
    }
}
