using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_1 : MonoBehaviour
{

    public static float speed = 15;
    public float hp = 150;
    public float money = 10;
    private float totalHp;
    public GameObject explosionEffect;
    private Slider hpSlider;
    private Transform[] positions;
    private int index = 0;

    //public paused control_p;

    // Use this for initialization
    void Start()
    {
        //if (firstPath) positions = Waypoints.positions;
        //else positions = Waypoints_2.positions;
        positions = Waypoints_2.positions;
        Debug.Log("WayPoints:" + positions.Length);
        totalHp = hp;
        hpSlider = GetComponentInChildren<Slider>();

        // control_p.control = 10;
    }

    // Update is called once per frame
    void Update()
    {
        //speed = control_p.control;
        Move();
    }

    void Move()
    {
        if (index > positions.Length - 1) return;
        transform.Translate((positions[index].position - transform.position).normalized * Time.deltaTime * speed);
        if (Time.deltaTime * speed >= Vector3.Distance(transform.position, positions[index].position))
        {
            index++;
        }
        else if (Vector3.Distance(positions[index].position, transform.position) < 0.2f)
        {
            index++;
        }
        if (index > positions.Length - 1)
        {
            ReachDestination();
        }
    }
    //达到终点
    void ReachDestination()
    {
        // GameManager.Instance.Failed ();
        // EndSlider.TakeDamage(hp);
        GameObject.Find("End").GetComponent<EndSlider>().TakeDamage(hp);
        GameObject.Destroy(this.gameObject);
    }

    void OnDestroy()
    {
        EnemySpawner.CountEnemyAlive--;
    }

    public void TakeDamage(float damage)
    {
        if (hp <= 0) return;
        Debug.Log("hp:" + hp);
        hp -= damage;
        hpSlider.value = (float)hp / totalHp;
        if (hp <= 0)
        {
            GameObject.Find("GameManager").GetComponent<BuildManager>().ChangeMoney((int)money);
            Die();
        }
    }
    void Die()
    {
        GameObject effect = GameObject.Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(effect, 1.5f);
        Destroy(this.gameObject);
    }

}