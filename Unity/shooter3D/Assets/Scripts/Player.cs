using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public GameObject Bullet;
    public Transform bulletSpawnPoint;
    public float fireRate;
    private float nextFire;
    private float precision = 5.125f;
    private float health = 10;
    private GameController gameController;

	void Start ()
	{
        health = 100;
        nextFire = Time.time;
        fireRate = 0.1f;
        gameController = (GameController) GameObject.FindGameObjectWithTag("GameController").GetComponent(typeof(GameController));
	}

	void FixedUpdate()
	{
		ControlShooting();
	}

	void ControlShooting()
	{
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            var ang = transform.rotation;
            var accuracyMin = (ang.eulerAngles.z - precision);
            var accuracyMax = (ang.eulerAngles.z + precision);
            var accuracy = Random.Range(accuracyMin, accuracyMax);
            ang.eulerAngles = new Vector3(ang.eulerAngles.x, ang.eulerAngles.y, accuracy);
            var spawnPoint = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            spawnPoint.y = (spawnPoint.y + 0.5f);
            spawnPoint.x = (spawnPoint.x * 1.5f);
            Instantiate(Bullet, bulletSpawnPoint.position, ang);
            gameController.ShotsFired();
        }
	}
    
    public float getHealth()
    {
        return health;
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
        gameController.Deaths();
        Destroy(gameObject);
    }
    
}