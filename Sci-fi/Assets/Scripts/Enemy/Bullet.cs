using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        var hitTransform = collision.transform;
        if (hitTransform.CompareTag("Player"))
        {
            hitTransform.GetComponent<PlayerHealth>().TakeDamage(10);
        }
        else if (hitTransform.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }
}
