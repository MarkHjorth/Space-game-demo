using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class Enemy : MonoBehaviour {

    private GameController gameController;
    private GameObject player;
    private EnemySpawnController spawner;
    public float health = 10;
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
    
    void setSpawner(EnemySpawnController spawner)
    {
        this.spawner = spawner;
    }
    
    public void Attack()
    {
        player.GetComponent<Player>().isHit(1);
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
        //var ang = transform.rotation;
        //Instantiate(corpse, transform.position, ang);
        spawner.SpawnEnemies(1);
        gameController.Kills();
        Destroy(gameObject);
    }
}
