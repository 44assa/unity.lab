using UnityEngine;

public class DestructibleTarget : MonoBehaviour
{
    public float destroyDelay = 0.1f; 

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Target hit by bullet! Destroying...");
            Destroy(gameObject, destroyDelay);
            Destroy(collision.gameObject);
        }
    }
}