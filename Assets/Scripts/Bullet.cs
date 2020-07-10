using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public int damage = 50;

    public float speed = 20;

    public GameObject explosionEffectPrefab;

    private float distanceArriveTarget = 1.2f;

    private Transform target;

    private bool useMissile;

    private bool isEnemy;

    public void SetTarget(Transform _target, bool useMissile, bool isEnemy)
    {
        this.target = _target;
        this.useMissile = useMissile;
        this.isEnemy = isEnemy;
    }

    void Update()
    {
        if (target == null)
        {
            Die();
            return;
        }

        transform.LookAt(target.position);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        Vector3 dir = target.position - transform.position;
        if (dir.magnitude < distanceArriveTarget)
        {
            if (useMissile) damage *= 2;
            if (isEnemy)
            {
                target.GetComponent<Enemy>().TakeDamage(damage);
            }
            else
            {
                target.GetComponent<Enemy_1>().TakeDamage(damage);
            }
            
            Die();   
        }
    }

    void Die()
    {
        GameObject effect = GameObject.Instantiate(explosionEffectPrefab, transform.position, transform.rotation);
        Destroy(effect, 1);
        Destroy(this.gameObject);
    }

}
