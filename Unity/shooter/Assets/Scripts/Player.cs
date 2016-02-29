using UnityEngine;
using System.Collections;

public class Player : Creature {

    public GameObject Bullet;
    public Stats stats;
    public float fireRate;
    private float nextFire;

	void Start ()
	{
        rb = GetComponent<Rigidbody2D>();
        isPlayer = true;
        weapon = gameObject.transform.FindChild("Weapon");
        stats = (Stats) GameObject.Find("StatsController").GetComponent(typeof(Stats));
        nextFire = Time.time;
        fireRate = 0.1f;
	}

	void FixedUpdate()
	{
		//Control mobility
		ControlRotation();
		ControlMovement();

		//Control shooting
		ControlShooting();
	}

	void ControlRotation()
	{
        var pos = Camera.main.WorldToScreenPoint(transform.position);
        var dir = Input.mousePosition - pos;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Vector3 forward = new Vector3(0f, 0f, 1f);
        transform.rotation = Quaternion.AngleAxis(angle, forward);
	}

	void ControlMovement()
	{
		//WASD Movement
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
        if(moveHorizontal != 0 || moveVertical != 0)
        {
		    Vector2 movement = new Vector2(moveHorizontal, moveVertical);
		    rb.AddForce (movement * speed);
        }

	}

	void ControlShooting()
	{
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            var ang = transform.rotation;
            var accuracyMin = (ang.eulerAngles.z - 5.125f);
            var accuracyMax = (ang.eulerAngles.z + 5.125f);
            var accuracy = Random.Range(accuracyMin, accuracyMax);
            ang.eulerAngles = new Vector3(ang.eulerAngles.x, ang.eulerAngles.y, accuracy);
            Instantiate(Bullet, weapon.position, ang);
            stats.ShotsFired++;
        }
	}
}