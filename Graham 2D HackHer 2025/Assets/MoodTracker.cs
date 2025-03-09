using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class MoodTracker : MonoBehaviour
{
    // Reference to the Text component where suggestions will be displayed
    public TMP_Text suggestionText;

    // Method to display a suggestion based on the selected mood
    public void OnMoodSelected(string mood)
    {
        // Default suggestion
        string suggestion = "Take a deep breath and relax!";

        // Suggestions based on the mood selected
        switch (mood)
        {
            case "Happy":
                suggestion = "Great! Keep up the positivity. Do something fun today!";
                break;
            case "Neutral":
                suggestion = "You're feeling neutral. Maybe engage in a hobby to lift your mood.";
                break;
            case "Stressed":
                suggestion = "Take a few deep breaths, maybe a quick walk or some stretching.";
                break;
            case "Sad":
                suggestion = "It's okay to feel sad. Take a break, listen to some calming music.";
                break;
            case "Burned Out":
                suggestion = "It's important to rest. Take a break and maybe try a relaxation technique.";
                break;
        }

        // Update the suggestion text on the UI
        suggestionText.text = "Suggestion: " + suggestion;
    }
}
