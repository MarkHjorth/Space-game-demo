using UnityEngine;
using System.Collections;

public class SmoothFollow : MonoBehaviour {

    public GameObject target;
    public float height = 5f;
    public float xOffset = 0f;
    public float zOffset = 0f;
    private Vector3 pos;
    // Use this for initialization
    void Start ()
    {
        pos = new Vector3(target.transform.position.x + xOffset, height, target.transform.position.z + zOffset);
    }
	
	// Update is called once per frame
	void Update ()
    {
        pos.x = target.transform.position.x + xOffset;
        pos.z = target.transform.position.z + zOffset;
        transform.position = pos;
	}
}
