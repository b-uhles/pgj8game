using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class Projectile : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;
    private int damage = 1;
    private float speed = 50f;
    private float horizontal = -1f;
    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed * Time.deltaTime, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Health>() != null)
        {
            Health health = collision.GetComponent<Health>();
            health.Damage(damage);
        }
        Destroy(gameObject);
    }
}
