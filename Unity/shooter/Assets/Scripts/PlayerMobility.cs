using UnityEngine;
using System.Collections;

public class PlayerMobility : MonoBehaviour {

	public float speed;
	private Rigidbody2D rb;
    public GameObject Bullet;
    public Quaternion rot;
    private Transform weapon;

	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
        weapon = transform.FindChild("Weapon");
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
		Vector2 movement = new Vector2(moveHorizontal, moveVertical);
		rb.AddForce (movement * speed);
	}

	void ControlShooting()
	{
        if(Input.GetButton("Fire1"))
		{
            var ang = transform.rotation;
            var accuracyMin = (ang.eulerAngles.z - 5.125f);
            var accuracyMax = (ang.eulerAngles.z + 5.125f);
            var accuracy = Random.Range(accuracyMin, accuracyMax);
            ang.eulerAngles = new Vector3(ang.eulerAngles.x, ang.eulerAngles.y, accuracy);
            Instantiate(Bullet, weapon.position, ang);
		}
	}
}


//Rotate from mouse movement
//var mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
//rot = Quaternion.LookRotation (transform.position - mousePosition, Vector3.forward);
//transform.rotation = rot;
//transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z);
//rb.angularVelocity = 0;