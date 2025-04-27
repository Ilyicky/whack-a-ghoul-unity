using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonColor2 : MonoBehaviour
{
    [SerializeField] private Button zombieButton;
    [SerializeField] private TextMeshProUGUI buttonText;

    void Start()
    {
        if (zombieButton != null)
        {
            ColorBlock colors = zombieButton.colors;

            colors.normalColor = new Color32(75, 83, 32, 255);     // Mucky green
            colors.highlightedColor = new Color32(178, 34, 34, 255); // Blood red
            colors.pressedColor = new Color32(46, 59, 18, 255);    // Dark green
            colors.disabledColor = new Color32(63, 76, 48, 128);   // Faded gray-green
            zombieButton.colors = colors;
        }

        if (buttonText != null)
        {
            buttonText.color = new Color32(223, 255, 214, 255); // Pale green
        }
    }
}
