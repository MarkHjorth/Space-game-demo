using UnityEngine;
using System.Collections;

public class Creature : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public Quaternion rot;
    public Transform weapon;
    public bool isPlayer = false;
    public float health = 100;
    public GameObject corpse;
    public GameObject player;

    void Start ()
    {
        
    }

}
