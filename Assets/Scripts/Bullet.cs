using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;

    public void Init(Vector2 direction)
    {
        rb.velocity = direction*speed;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);


        }
        if (other.gameObject.tag == "trooper")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);

        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
