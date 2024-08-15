using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] private GameObject defaultProjectile;
    [SerializeField] private GameObject owner;
    [SerializeField] private float shootInterval = 1f;

    // Update is called once per frame
    void Start()
    {

        StartCoroutine(spawnProjectile(shootInterval, defaultProjectile));
    }

    private IEnumerator spawnProjectile(float interval, GameObject projectile)
    {
        yield return new WaitForSeconds(interval);
        GameObject newProjectile = Instantiate(projectile, new Vector3(owner.transform.position.x + -1f, owner.transform.position.y), Quaternion.identity);
        StartCoroutine(spawnProjectile(interval,projectile));
    }
}
