using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    //Dictionary<string, TMP_Text> inventoryTexts = new Dictionary<string, TMP_Text>();
    public TMP_Text bonesText;
    public TMP_Text beersText;
    public TMP_Text forksText;

    private void Start()
    {
        bonesText.text = "Bones: 0";
        beersText.text = "Beers: 0";
        forksText.text = "Forks: 0";
    }

    public void UpdateText(string text, int value)
    {
        switch(text)
        {
            case "bones":
                bonesText.text = "Bones: " + value.ToString(); 
                break;
            case "beers":
                beersText.text = "Beers: " + value.ToString();
                break;
            case "forks":
                forksText.text = "Forks: " + value.ToString();
                break;
        }
    }
}