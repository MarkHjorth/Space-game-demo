using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {
    public ParticleSystem p;

	// Use this for initialization
	void Start () {
	    p = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        if(!p.IsAlive())
        {
            Destroy(gameObject);
        }
	}
    
    void OnParticleCollision(GameObject other) {
        
        var enemy = (Enemy) other.GetComponent(typeof(Enemy));
        enemy.isHit(1);
        
        /*Rigidbody body = other.GetComponent<Rigidbody>();
        if (body) {
            Vector3 direction = other.transform.position - transform.position;
            direction = direction.normalized;
            body.AddForce(direction * 5);
        }*/
        
        
    }
}
