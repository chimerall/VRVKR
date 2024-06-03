using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class TaskManagerScript : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public Button button3;
    public Button nextTaskButton;
    public Button completeTaskButton; // Кнопка для подтверждения выполнения задания
    public TextMeshProUGUI taskList;
    public GameObject resultsMenu; // Меню результатов

    public Button fixIssueButton; // Reference to the "Fix Issue" Button
    public Button powerOffButton; // Reference to the "Power Off" Button
    public Button calibrateButton; // Reference to the "Calibrate" Button
    public Button replacePowerBlockButton; // Reference to the "Replace Power Block" Button
    public TMP_Dropdown speedDropdown; // Reference to the Dropdown menu
    public Button applyChangesButton; // Reference to the "Apply Changes" button

    private List<string> currentTasks;
    private System.Random random;
    private string currentTask;
    private bool isTaskCompleted;

    void Start()
    {
        // Привязываем функции к кнопкам
        button1.onClick.AddListener(() => ShowTaskList(new List<string> {
            "Устраните засор печатающей головки",
            "Выполните замену блока питания",
            "Выполните повторную калибровку платформы",
            "Измените управляющие параметры скорости печати"
        }));

        button2.onClick.AddListener(() => ShowTaskList(new List<string> {
            "Выполните повторную калибровку положения",
            "Измените параметры резки в управляющем ПО",
            "Устраните загрязнения в направляющих и рельсах",
            "Выполните замену блока питания"
        }));

        button3.onClick.AddListener(() => ShowTaskList(new List<string> {
            "Выполните проверку состояния механических компонентов",
            "Выполните замену фрезы",
            "Выполните повторную калибровку положения",
            "Выполните замену блока питания"
        }));

        nextTaskButton.onClick.AddListener(ShowNextTask);
        completeTaskButton.onClick.AddListener(CompleteCurrentTask);

        // Инициализация
        currentTasks = new List<string>();
        random = new System.Random();
        taskList.text = "Выберите список задач";
        resultsMenu.SetActive(false); // Скрываем меню результатов по умолчанию
        completeTaskButton.gameObject.SetActive(false); // Скрываем кнопку завершения задачи по умолчанию
        isTaskCompleted = false;
    }

    void ShowTaskList(List<string> tasks)
    {
        currentTasks = new List<string>(tasks);
        resultsMenu.SetActive(false); // Скрываем меню результатов при выборе нового списка задач
        ShowNextTask();
    }

    void ShowNextTask()
    {
        if (currentTasks.Count > 0)
        {
            int randomIndex = random.Next(currentTasks.Count);
            currentTask = currentTasks[randomIndex];
            taskList.text = currentTask;
            currentTasks.RemoveAt(randomIndex);
            isTaskCompleted = false;
            completeTaskButton.gameObject.SetActive(true); // Показываем кнопку завершения задачи


            // Show or hide buttons based on the selected task
            if (currentTask == "Выполните замену блока питания")
            {
                powerOffButton.gameObject.SetActive(true);
                replacePowerBlockButton.gameObject.SetActive(true);
            }
            else if (currentTask == "Выполните повторную калибровку платформы")
            {
                calibrateButton.gameObject.SetActive(true);
                powerOffButton.gameObject.SetActive(false);
                replacePowerBlockButton.gameObject.SetActive(false);
            }
            else if (currentTask == "Измените управляющие параметры скорости печати")
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
        else
        {
            taskList.text = "Все задачи выполнены";
            ShowResultsMenu();
        }
    }

    void CompleteCurrentTask()
    {
        if (!isTaskCompleted)
        {
            isTaskCompleted = true;
            completeTaskButton.gameObject.SetActive(false); // Скрываем кнопку завершения задачи
            ShowNextTask(); // Показать следующее задание
        }
    }

    void ShowResultsMenu()
    {
        resultsMenu.SetActive(true); // Показываем меню результатов
    }
}
