using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonColor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Button myButton;  // Reference to your button
    [SerializeField] private TextMeshProUGUI buttonText;  // Reference to the Text component on the button

    // Neon colors for button and text
    private Color darkGreenColor = new Color32(0, 128, 0, 255); //dark green color
    private Color neonGreenColor = new Color32(0, 255, 0, 255);//neon green color
    private Color whiteTextColor = new Color32(255, 255, 255, 255);  // White text on hover

    void Start()
    {
        if (myButton != null && buttonText != null)
        {
            //set button color
            ColorBlock colorBlock = myButton.colors;
            colorBlock.normalColor = darkGreenColor;
            colorBlock.highlightedColor = neonGreenColor;
            myButton.colors = colorBlock;

            //set text of the button color
            buttonText.color = neonGreenColor;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //change the text's color when hovered
        buttonText.color = whiteTextColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //bring back to normal on pointer exit
        buttonText.color = neonGreenColor;
    }
}
