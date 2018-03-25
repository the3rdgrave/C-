using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    
    public Text WavesIndex;

    public static int EnemiesAlive = 0;
    public GameObject WinUI;
    public   Wave[] waves;

   // public Transform enemyPrefab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 10f;

    public Text waveCountdownText;

    private int waveIndex = 0;
    // Update is called once per frame

        void Start()
    {
      //  WinUI.SetActive(true);
    }
    void Update()
    {
        //printing on the ui the waves number
        WavesIndex.text = "Wave: " + waveIndex.ToString() + "/" + waves.Length.ToString();

        //  Debug.Log(EnemiesAlive + " Enemiesalive");
        if (EnemiesAlive > 0)
        {
            return;
        }
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveCountdownText.text = string.Format("{0:00}" + "S", countdown);

       
    }
    //spawning waves in the starting waypoint
    IEnumerator SpawnWave()
    {
        
        PlayerStats.Rounds++;

        Wave wave = waves[waveIndex];

        for (int i = 0; i < wave.count; i++)
        {
          // Debug.Log(waveIndex + " /" + waves.Length);

            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
           
        }
        waveIndex++;
        if (waveIndex == waves.Length) //&& (EnemiesAlive == 0))
        {

            WinUI.SetActive(true);
            
        }
    }

    void SpawnEnemy(GameObject enemy)
    {

        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        
        EnemiesAlive++;
        
    }
}



