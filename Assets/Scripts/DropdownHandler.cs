using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DropdownHandler : MonoBehaviour
{
    public TMP_Dropdown dropdown; // Reference to the TMP_Dropdown element
    public Button applyButton; // Reference to the "Apply Changes" Button
    public TextMeshProUGUI hintText; // Reference to the TextMeshProUGUI element for the hint text
    public Button fixIssueButton; // Reference to the "Fix Issue" Button

    private void Start()
    {
        // Initially hide the apply button, hint text, and fix issue button
        applyButton.gameObject.SetActive(false);
        hintText.gameObject.SetActive(false);
        fixIssueButton.gameObject.SetActive(false);

        // Add a listener to the dropdown to call the OnDropdownValueChanged method when an option is selected
        dropdown.onValueChanged.AddListener(OnDropdownValueChanged);

        // Add a listener to the apply button to call the OnApplyButtonClicked method when clicked
        applyButton.onClick.AddListener(OnApplyButtonClicked);
    }

    // Method to handle dropdown value changes
    public void OnDropdownValueChanged(int index)
    {
        // Show the apply button whenever the dropdown selection changes
        applyButton.gameObject.SetActive(true);
    }

    // Method to handle apply button click
    public void OnApplyButtonClicked()
    {
        // Get the selected option text
        string selectedOption = dropdown.options[dropdown.value].text;

        // Update the hint text and show it
        hintText.text = "Выбрана температура: " + selectedOption;
        hintText.gameObject.SetActive(true);

        // Hide the apply button
        applyButton.gameObject.SetActive(false);

        // Show the fix issue button
        fixIssueButton.gameObject.SetActive(true);
    }
}
