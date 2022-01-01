using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float VelocityToDestroy;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log(collision.relativeVelocity.magnitude);

        if (collision.relativeVelocity.magnitude > VelocityToDestroy)
        {
            Destroy(gameObject);
        }
    }
}
