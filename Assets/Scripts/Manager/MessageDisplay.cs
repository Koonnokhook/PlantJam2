using TMPro;
using UnityEngine;

public class MessageDisplay : MonoBehaviour
{
    public TextMeshProUGUI messageText;

    // Call this function to display a message
    public void DisplayMessage(string message)
    {
        if (messageText != null)
        {
            messageText.text = message;
        }
    }
}
