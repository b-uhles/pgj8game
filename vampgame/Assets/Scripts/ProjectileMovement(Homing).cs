using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEditor.U2D.Aseprite;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class ProjectileMovement : MonoBehaviour
{
    [SerializeField]
    public GameObject owner,target;
    private float horizontal;
    public bool isHoming, isLocked = false;
    private Vector3 position;
    private Vector3 velocity;
    private Vector3 P0,P1,P2,P3;
    private float t1 = 0;
    [SerializeField] private LayerMask hostile;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = owner.transform.position;
        position = transform.position;
        velocity = Vector3.zero;
        if (isHoming)
        {
            P0 = new Vector3(transform.position.x,transform.position.y);
            P1 = new Vector3(0, Random.Range(-5, 5));
            if (!isLocked) P2 = new Vector3(transform.position.x, transform.position.y);
            else P2 = owner.transform.position + (target.transform.position - owner.transform.position) * .5f;
            Debug.Log($"{P0},,,{P1},,,{P2},,,{target.transform.position}");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isHoming)
        {
            if (isLocked) P3 = target.transform.position;
            else P3 = P1 + Vector3.right * 100;
            Debug.Log(P3);
            t1 += .4f * Time.deltaTime;
            if (t1 > 1) t1 = 1;
            float t = t1 * t1;
            position =
                P0 * (-t * t * t + 3 * t * t - 3 * t + 1) +
                P1 * (3 * t * t * t - 6 * t * t + 3 * t) +
                P2 * (-3 * t * t * t + 3 * t * t) +
                P3 * (t * t * t);


            transform.position = position;

            transform.rotation = Quaternion.LookRotation(position);
        }
        else
        {
            transform.position += new Vector3(20 * Time.deltaTime, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.layer);
        if (collision.GetComponent<Health>() != null && collision.gameObject.layer == hostile)
        {
            Health health = collision.GetComponent<Health>();
            health.Damage(1);
            Destroy(gameObject);
            Debug.Log("hit");
        }
    }
}
