using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class InputManager : MonoBehaviour
{
    private PlayerMove playerMove;

    private void Start()
    {
        playerMove = INSTANCE.player.GetComponent<PlayerMove>();
    }

    void Update()
    {
        if (!INSTANCE.gameIsPaused)
        {
            if (Input.GetMouseButtonDown(0))
            {
                playerMove.SetDestination();
            }

            if (Input.GetMouseButtonDown(1))
            {
                bool success = INSTANCE.onCastSpell();
                if (success)
                {
                    INSTANCE.uiManager.SubmitSpell();
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            INSTANCE.uiManager.ShiftSlot("boil");
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            INSTANCE.uiManager.ShiftSlot("crush");
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            INSTANCE.uiManager.ShiftSlot("dry");
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            INSTANCE.uiManager.OpenInventory();
            INSTANCE.TogglePauseGame();
        }
    }
}
