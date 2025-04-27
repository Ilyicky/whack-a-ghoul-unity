using UnityEngine;
using UnityEngine.UI;

public class SaveButton : MonoBehaviour
{
    private Button button;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => button.interactable = false);    
    }
}
