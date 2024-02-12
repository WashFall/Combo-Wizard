using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerMove playerMove;
    public GameObject playerObject;

    public float maxPlayerHealth = 100;
    public float currentPlayerHealth = 100;

    private void Start()
    {
        playerMove = GetComponent<PlayerMove>();
        playerObject = gameObject;
    }

    public void TakeDamage(float damage)
    {
        if (currentPlayerHealth > 0)
        {
            currentPlayerHealth -= damage;
            GameManager.INSTANCE.onDamageTaken(maxPlayerHealth, currentPlayerHealth);
        }
    }

    public void Heal(float hp)
    {
        if(currentPlayerHealth < maxPlayerHealth)
        {
            currentPlayerHealth += hp;
            if(currentPlayerHealth >= maxPlayerHealth)
            {
                currentPlayerHealth = maxPlayerHealth;
            }
            GameManager.INSTANCE.onDamageTaken(maxPlayerHealth, currentPlayerHealth);
        }
    }
}
