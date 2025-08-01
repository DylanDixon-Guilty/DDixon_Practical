using JetBrains.Annotations;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{


    [SerializeField] private int damage = 10;
    private bool playerInRange;
    

    private void OnTriggerEnter(Collider other)
    {
        playerInRange = true;
        if (playerInRange)
        {
            GameManager.instance.playerHealth.PlayerTakeDamage(damage);
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        playerInRange = false;
        if (!playerInRange)
        {
            return;
        }
    }
}
