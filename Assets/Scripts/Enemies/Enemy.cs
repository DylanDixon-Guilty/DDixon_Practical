using System;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public int MaxHealth;
    public int CurrentHealth;
    public int ScorePoints;

    private Transform playerPosition;
    private NavMeshAgent navAgent;

    void Awake()
    {
        CurrentHealth = MaxHealth;
        navAgent = GetComponent<NavMeshAgent>();
    }

    public void Initialized(Transform playerTransform)
    {
        playerPosition = playerTransform;
        navAgent.SetDestination(playerPosition.position);
    }

    // Update is called once per frame
    void Update()
    {   
        if(CurrentHealth > 0)
        {
            if(playerPosition != null)
            {
                navAgent.SetDestination(playerPosition.position);
            }
        }
        else
        {
            HasDied();
        }
    }

    public void TakenDamage(int damageAmount)
    {
        if (CurrentHealth > 0)
        {
            CurrentHealth = Mathf.Max(CurrentHealth - damageAmount, 0);
        }
    }

    private void HasDied()
    {
        Destroy(gameObject);
    }
}
