using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int MaxHealth;
    public int CurrentHealth;
    public event Action<int, int> OnHealthChange;

    private PlayerMove playerMove;
    private PlayerShoot playerShoot;

    private void Awake()
    {
        CurrentHealth = MaxHealth;
        playerMove = GetComponent<PlayerMove>();
        playerShoot = GetComponent<PlayerShoot>();
    }

    public void PlayerTakeDamage(int damageAmount)
    {
        if(CurrentHealth > 0)
        {
            CurrentHealth = Mathf.Max(CurrentHealth - damageAmount, 0);
            OnHealthChange?.Invoke(CurrentHealth, MaxHealth);
        }
        if(CurrentHealth <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        playerMove.enabled = false;
        playerShoot.enabled = false;
        Debug.Log("You Died!!");
    }
}
