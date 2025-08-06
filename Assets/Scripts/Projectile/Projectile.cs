using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Force = 1000f;
    public float LifeTime = 5f;

    [SerializeField] private int damage = 10;
    private Rigidbody projectileRb;

    private void Awake()
    {
        projectileRb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        projectileRb.AddForce(transform.forward * Force);
        StartCoroutine(DespawnProjectile());
    }

    IEnumerator DespawnProjectile()
    {
        yield return new WaitForSeconds(LifeTime);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if(enemy != null)
        {
            enemy.TakenDamage(damage);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
