using JetBrains.Annotations;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{


    [SerializeField] private int damage = 10;
    

    private void OnTriggerEnter(Collider other)
    {
        PlayerMove player = other.GetComponent<PlayerMove>();
        if(player != null)
        {
            GameManager.instance.playerHealth.PlayerTakeDamage(damage);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
}
