using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonColor2 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Button mySecondButton;
    [SerializeField] private TextMeshProUGUI buttonText;

    private Color muckyGreenColor = new Color32(75, 83, 32, 255);
    private Color redColor = new Color32(178, 34, 34, 255);
    private Color darkGreenColor = new Color32(46, 59, 18, 255);
    private Color lightGreenColor = new Color32(223, 255, 214, 255);

    void Start()
    {
        if (mySecondButton != null && buttonText != null)
        {
            ColorBlock colorBlock = mySecondButton.colors;
            colorBlock.normalColor = muckyGreenColor;
            colorBlock.highlightedColor = redColor;
            colorBlock.pressedColor = darkGreenColor;
            mySecondButton.colors = colorBlock;

            buttonText.color = lightGreenColor;
        }   
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        //change the text's color when hovered
        buttonText.color = lightGreenColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //bring back to normal on pointer exit
        buttonText.color = lightGreenColor;
    }
}
