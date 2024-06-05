using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResultScript : MonoBehaviour
{
    public Timer timerScript; // Ссылка на скрипт Timer
    public TaskScript taskScript; // Ссылка на скрипт TaskScript
    public Button finishWorkButton; // Кнопка "Завершить работу"
    public TextMeshProUGUI resultText; // Текст для отображения результатов

    private void Start()
    {
        // Добавить слушатель на кнопку "Завершить работу"
        finishWorkButton.onClick.AddListener(ShowResults);
    }

    // Метод для отображения результатов и остановки таймера
    private void ShowResults()
    {
        // Остановить таймер
        timerScript.BtnTimer();

        // Подсчитать количество завершенных заданий
        int completedTasksCount = 0;
        foreach (bool isCompleted in taskScript.CompletedTasks)
        {
            if (isCompleted)
            {
                completedTasksCount++;
            }
        }

        // Получить затраченное время
        float elapsedTime = timerScript.timeStart;

        // Отобразить результаты
        resultText.text = $"Устранено неполадок: {completedTasksCount}\nЗатраченное время: {elapsedTime:F2} секунд";
    }
}
