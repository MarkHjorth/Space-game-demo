using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{

    private GameSession GameSession;
    private Player player;
    private Stats stats;
    private PauseController pauseController;
    private GameObject Hud;
    private EnemySpawnController spawner;
    public GameObject PauseMenuPrefab;
    public GameObject HudPrefab;

    // Use this for initialization
    void Start()
    {
        stats = gameObject.AddComponent<Stats>() as Stats;
        pauseController = gameObject.AddComponent<PauseController>() as PauseController;
        pauseController.SetPauseMenu(PauseMenuPrefab);
        player = (Player)GameObject.FindGameObjectWithTag("Player").GetComponent(typeof(Player));
        spawner = (EnemySpawnController)GameObject.FindGameObjectWithTag("EnemySpawner").GetComponent(typeof(EnemySpawnController));
        Hud = Instantiate(HudPrefab);

    }

    public Player getPlayer()
    {
        return player;
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void spawnEnemy(int amount)
    {
        spawner.SpawnEnemies(amount);
    }

    public void ShotsHit()
    {
        stats.ShotsHit++;
    }
    public void Deaths()
    {
        stats.Deaths++;
    }
    public void Kills()
    {
        stats.Kills++;
    }
    public void ShotsFired()
    {
        stats.ShotsFired++;
    }
    public void saveStats()
    {
        stats.SaveStats();
    }
}
