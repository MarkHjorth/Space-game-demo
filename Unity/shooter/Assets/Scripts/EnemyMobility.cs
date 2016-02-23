using UnityEngine;
using System.Collections;

public class EnemyMobility : MonoBehaviour {

    public float speed;
    //private Rigidbody2D rb;
    public Quaternion rot;
    public GameObject target;
    public float health = 100;

    void Start ()
    {
        //rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //Control mobility
        ControlRotation();

    }

    void ControlRotation()
    {
        var pos = Camera.main.WorldToScreenPoint(transform.position);
        var dir = target.transform.position - pos;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Vector3 forward = new Vector3(0f, 0f, 1f);
        transform.rotation = Quaternion.AngleAxis(angle, forward);
    }

    public void isHit(int damage)
    {
        health = health - damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
