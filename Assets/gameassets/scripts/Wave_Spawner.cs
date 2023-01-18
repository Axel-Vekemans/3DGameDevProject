using UnityEngine;
using System.Collections;
using TMPro;

public class Wave_Spawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;


    public Wave[] waves;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 10f;

    public TextMeshProUGUI waveCountdownText;

    private int waveNumber = 0;
    public GameManager gameManager;

    void Start()
    {
        EnemiesAlive = 0;
    }

    void Update()
    {
        if(EnemiesAlive > 0)
        {
            return;
        }
        if (waveNumber == waves.Length)
        {
            Debug.Log("level won!");

            gameManager.WinLevel();
            return;

        }
        if (countdown <= 0f)
        {
            StartCoroutine(Spawnwave());
            countdown = timeBetweenWaves;
            return;
        }
        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator Spawnwave()
    {
        PlayerStats.Rounds++;

        Wave wave = waves[waveNumber];

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }


        waveNumber++;


        
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
    }
}
