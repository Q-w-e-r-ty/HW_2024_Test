using System.Collections;
using UnityEngine;
using TMPro; // Ensure this is included for TextMeshPro

public class PlaneTimer : MonoBehaviour
{
    private TextMeshProUGUI textMesh; // For TextMeshProUGUI
    private float destructionTime;

    void Start()
    {
        // Try to get the TextMeshProUGUI component from child objects
        textMesh = GetComponentInChildren<TextMeshProUGUI>();

        // Check if the textMesh was found
        if (textMesh == null)
        {
            Debug.LogError("TextMeshProUGUI component not found on any child GameObject!");
            return;
        }

        // Set the destruction time to 1 second from now
        destructionTime = Time.time + 2f;

        // Start the countdown update coroutine
        StartCoroutine(UpdateCountdown());
    }

    IEnumerator UpdateCountdown()
    {
        while (Time.time < destructionTime)
        {
            // Calculate the remaining time
            float timeLeft = destructionTime - Time.time;

            // Update the text with the remaining time
            textMesh.text = timeLeft.ToString("F1") + "s";

            // Wait for the next frame
            yield return null;
        }

        // Ensure the text is set to "0.0s" when destroyed
        textMesh.text = "0.0s";
    }
}
