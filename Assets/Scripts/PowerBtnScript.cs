using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PowerBtnScript : MonoBehaviour
{
    public Button powerButton; // Ссылка на кнопку питания
    public TextMeshProUGUI powerButtonText; // Ссылка на текст на кнопке питания
    public Button replacePowerBlockButton; // Ссылка на кнопку "Заменить блок питания"
    public GameObject replacePowerBlockTooltip; // Ссылка на объект с подсказкой

    private bool isPowerOn = true; // Состояние питания

    void Start()
    {
        // Установить начальное состояние кнопки
        SetButtonState();
        replacePowerBlockButton.gameObject.SetActive(false); // Скрыть кнопку "Заменить блок питания"
        replacePowerBlockTooltip.SetActive(false); // Скрыть подсказку
        
        // Добавить слушатель нажатия на кнопку
        powerButton.onClick.AddListener(TogglePower);
        replacePowerBlockButton.onClick.AddListener(ReplacePowerBlock);
    }

    void SetButtonState()
    {
        if (isPowerOn)
        {
            powerButton.GetComponent<Image>().color = Color.green; // Установить зелёный цвет
            powerButtonText.text = "ON"; // Установить текст "ON"
        }
        else
        {
            powerButton.GetComponent<Image>().color = Color.gray; // Установить серый цвет
            powerButtonText.text = "OFF"; // Установить текст "OFF"
        }
    }

    public void TogglePower()
    {
        isPowerOn = !isPowerOn; // Переключить состояние питания

        SetButtonState(); // Обновить состояние кнопки

        if (isPowerOn)
        {
            replacePowerBlockButton.gameObject.SetActive(false); // Скрыть кнопку "Заменить блок питания"
            replacePowerBlockTooltip.SetActive(false); // Скрыть подсказку
        }
        else
        {
            replacePowerBlockButton.gameObject.SetActive(true); // Показать кнопку "Заменить блок питания"
            replacePowerBlockTooltip.SetActive(false); // Скрыть подсказку
        }
    }

    public void ReplacePowerBlock()
    {
        replacePowerBlockTooltip.SetActive(true); // Показать подсказку
        replacePowerBlockButton.gameObject.SetActive(false); // Скрыть кнопку "Заменить блок питания"
        powerButton.gameObject.SetActive(true);
    }
}
