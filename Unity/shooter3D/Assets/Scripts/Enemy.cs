using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class Enemy : MonoBehaviour {

    private GameController gameController;
    private GameObject player;
    private EnemySpawnController spawner;
    private float health = 10;
    private AICharacterControl aiControl;

    void Start ()
    {
        //rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        gameController = (GameController) GameObject.FindGameObjectWithTag("GameController").GetComponent(typeof(GameController));
        aiControl = (AICharacterControl) gameObject.GetComponent(typeof(AICharacterControl));
        aiControl.SetTarget(player.transform);
    }

    void FixedUpdate()
    {
        //Control mobility

    }
    
    public float getHealth()
    {
        return health;
    }
    
    public void Attack()
    {
        player.GetComponent<Player>().isHit(1);
    }

    public void isHit(int damage)
    {
        health -= damage;
        gameController.ShotsHit();
        if (health <= 0)
        {
            die();
        }
    }

    public void die()
    {
        //var ang = transform.rotation;
        //Instantiate(corpse, transform.position, ang);
        gameController.spawnEnemy(1);
        gameController.Kills();
        Destroy(gameObject);
    }
}
