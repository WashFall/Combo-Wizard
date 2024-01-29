using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    //Dictionary<string, TMP_Text> inventoryTexts = new Dictionary<string, TMP_Text>();
    public GameObject inventoryPanel;

    private void Start()
    {
        inventoryPanel.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
            GameManager.INSTANCE.TogglePauseGame();
        }
    }
}