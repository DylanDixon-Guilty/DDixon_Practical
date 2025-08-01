using Unity.VisualScripting;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject ProjectilePrefab;
    public Transform FirePointPosition;

    private string space = "Jump";

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) || Input.GetButtonDown(space))
        {
            Instantiate(ProjectilePrefab, FirePointPosition.position, transform.rotation);
        }
    }
}
