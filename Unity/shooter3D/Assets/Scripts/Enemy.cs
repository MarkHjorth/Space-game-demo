using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    private GameController gameController;
    private GameObject player;
    public float health = 10;

    void Start ()
    {
        //rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        gameController = (GameController) GameObject.FindGameObjectWithTag("GameController").GetComponent(typeof(GameController));
    }

    void FixedUpdate()
    {
        //Control mobility

    }

    public void isHit(int damage)
    {
        health = health - damage;
        gameController.ShotsHit();
        if (health <= 0)
        {
            die();
        }
    }

    public void die()
    {
        var ang = transform.rotation;
        //Instantiate(corpse, transform.position, ang);
        gameController.Kills();
        Destroy(gameObject);
    }
}
