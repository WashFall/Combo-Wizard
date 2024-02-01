using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject inventoryPanel;
    public List<Transform> inventorySlots;
    public Image boil, crush, dry;
    private int boilIndex = -3, crushIndex = -2, dryIndex = -1;

    private void Start()
    {
        foreach (Transform slot in inventoryPanel.transform)
        {
            inventorySlots.Add(slot);
        }
        inventoryPanel.SetActive(false);
        boil.preserveAspect = true;
        crush.preserveAspect = true;
        dry.preserveAspect = true;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
            GameManager.INSTANCE.TogglePauseGame();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            boilIndex += 3;
            if(boilIndex > 6)
            {
                boilIndex = 0;
            }
            boil.sprite = inventorySlots[boilIndex].GetChild(0).GetComponent<Image>().sprite;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            crushIndex += 3;
            if(crushIndex > 7)
            {
                crushIndex = 1;
            }
            crush.sprite = inventorySlots[crushIndex].GetChild(0).GetComponent<Image>().sprite;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            dryIndex += 3;
            if(dryIndex > 8)
            {
                dryIndex = 2;
            }
            dry.sprite = inventorySlots[dryIndex].GetChild(0).GetComponent<Image>().sprite;
        }

        if (Input.GetMouseButtonDown(1))
        {
            boilIndex = -3;
            crushIndex = -2;
            dryIndex = -1;
        }
    }
}