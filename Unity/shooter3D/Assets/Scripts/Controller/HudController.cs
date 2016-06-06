using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HudController : MonoBehaviour {
    
    public Text healthText;
    private GameController gameController;
    private float currentHealth;

	// Use this for initialization
	void Start ()
    {
        gameController = (GameController) GameObject.FindGameObjectWithTag("GameController").GetComponent(typeof(GameController));
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        currentHealth = gameController.getPlayer().getHealth();
        healthText.text = ("Health: " + currentHealth);
	
	}
}
