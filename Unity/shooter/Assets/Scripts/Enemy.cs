using UnityEngine;
using System.Collections;

public class Enemy : Creature {

    public Stats stats;

    void Start ()
    {
        //rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        stats = (Stats) GameObject.Find("StatsController").GetComponent(typeof(Stats));
    }

    void FixedUpdate()
    {
        //Control mobility
        ControlRotation();

    }

    void ControlRotation()
    {
        var pos = transform.position;
        var dir = player.transform.position - pos;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Vector3 forward = new Vector3(0f, 0f, 1f);
        transform.rotation = Quaternion.AngleAxis(angle, forward);
    }

    public void isHit(int damage)
    {
        health = health - damage;
        stats.ShotsHit++;
        if (health <= 0)
        {
            die();
        }
    }

    public void die()
    {
        var ang = transform.rotation;
        Instantiate(corpse, transform.position, ang);
        stats.Kills++;
        Destroy(gameObject);
    }
}
