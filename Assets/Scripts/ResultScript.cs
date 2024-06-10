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

        // Подсчитать баллы на основе времени и количества заданий
        int score = CalculateScore(completedTasksCount, elapsedTime);

        // Отобразить результаты
        resultText.text = $"Устранено неполадок: {completedTasksCount}\nЗатраченное время: {elapsedTime:F2} секунд\nБаллы: {score}";
    }

    // Метод для расчета баллов
    private int CalculateScore(int completedTasksCount, float elapsedTime)
    {
        // Предположим, что за каждую устраненную неполадку даётся 10 баллов, 
        // а за каждую секунду, которую удалось сэкономить, даётся 5 баллов.
        int taskScore = completedTasksCount * 10;
        int timeScore = Mathf.RoundToInt((100 - elapsedTime) * 5); // 100 - elapsedTime - чтобы чем быстрее, тем больше баллов

        // Суммируем баллы
        int totalScore = taskScore + timeScore;

        // Минимальное количество баллов за работу - 0
        return Mathf.Max(totalScore, 0);
    }
}
