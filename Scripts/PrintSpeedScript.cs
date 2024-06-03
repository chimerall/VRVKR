using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PrintSpeedScript : MonoBehaviour
{
    public TMP_Dropdown speedDropdown; // Reference to the Dropdown menu
    public Button applyButton; // Reference to the Apply button
    public TextMeshProUGUI resultText; // Reference to the Text element

    private void Start()
    {
        // Add options to the dropdown menu
        speedDropdown.options.Clear();
        speedDropdown.options.Add(new TMP_Dropdown.OptionData("Slow"));
        speedDropdown.options.Add(new TMP_Dropdown.OptionData("Medium"));
        speedDropdown.options.Add(new TMP_Dropdown.OptionData("Fast"));

        // Set the default selected option to "Fast"
        speedDropdown.value = 2;

        // Initially hide the apply button
        applyButton.gameObject.SetActive(false);

        // Add listener to the dropdown to show the apply button when the value changes
        speedDropdown.onValueChanged.AddListener(delegate { OnSpeedChanged(); });

        // Add listener to the apply button to call the ApplySpeed method when clicked
        applyButton.onClick.AddListener(ApplySpeed);
    }

    // Method called when the dropdown value changes
    private void OnSpeedChanged()
    {
        // Show the apply button
        applyButton.gameObject.SetActive(true);
    }

    // Method called when the apply button is clicked
    private void ApplySpeed()
    {
        string selectedSpeed = speedDropdown.options[speedDropdown.value].text;
        string resultMessage = $"Скорость печати: {selectedSpeed}";

        // Add a warning message based on the selected speed
        if (selectedSpeed == "Slow")
        {
            resultMessage += " - Скорость печати слишком низкая.";
        }
        else if (selectedSpeed == "Fast")
        {
            resultMessage += " - Скорость печати слишком высокая.";
        }

        // Update the result text
        resultText.text = resultMessage;

        // Hide the apply button after applying the changes
        applyButton.gameObject.SetActive(false);
    }
}
