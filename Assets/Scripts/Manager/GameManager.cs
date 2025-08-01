using UnityEngine;



public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public PlayerHealth playerHealth;
    public EnemyStats enemyHealth;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
            return;
        }
        playerHealth = GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyStats>();
    }
}
