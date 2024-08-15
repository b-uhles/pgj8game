using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private GameObject attackArea;
    private bool isAttacking = false;
    private float timeToAttack = 0.3f;
    private float time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Attack();
        if (isAttacking)
        {
            time += Time.deltaTime;
            if (time > timeToAttack)
            {
                time = 0;
                isAttacking = false;
                attackArea.SetActive(isAttacking);
            }
        }
    }

    private void Attack()
    {
        isAttacking = true;
        attackArea.SetActive(isAttacking);
    }
}
