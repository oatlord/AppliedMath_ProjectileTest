using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class ProjectileSpawn : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // public GameObject projectile;
    public Transform spawnPoint;
    public GameObject projectilePrefab;
    public float launchAcceleration = 10f;
    public float initialVelocity = 5f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireProjectile();            
        }
    }

    void FireProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, spawnPoint.position, quaternion.identity);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();

        if (rb != null)
        {
            float time = 1f;
            Vector3 launchForce = (0.5f * launchAcceleration * time * time * +initialVelocity * time) * spawnPoint.forward;

            Debug.Log("Launching projectile at force: " + launchForce);

            rb.AddForce(launchForce, ForceMode.Impulse);
        }
        else
        {
            Debug.LogError("No rigidbody!");
        }
    }
}
