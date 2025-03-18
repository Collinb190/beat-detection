using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    [SerializeField] private GameObject arrowPrefab; // Arrow to spawn
    [SerializeField] private Transform spawnPoint; // Where arrows will be spawned
    [SerializeField] private float spawnTempo; // BPM-based spawn rate
    [SerializeField] private AudioSource audioSource;

    private bool hasStarted = false;
    private float nextSpawnTime = 0f;

    void Start()
    {
        spawnTempo = 60f / spawnTempo;
    }

    void Update()
    {
        if (!hasStarted)
        {
            if (audioSource.isPlaying)
            {
                hasStarted = true;
                nextSpawnTime = Time.time; // Sync first spawn with the music
            }
            else
            {
                return; // Wait for the audio to start
            }
        }

        // Spawn arrows at the correct tempo
        if (Time.time >= nextSpawnTime)
        {
            SpawnArrow();
            nextSpawnTime += spawnTempo; // Schedule the next spawn
        }
    }

    void SpawnArrow()
    {
        Instantiate(arrowPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
