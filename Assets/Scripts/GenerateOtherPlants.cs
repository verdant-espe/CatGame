using UnityEngine;

public class GenerateOtherPlants : MonoBehaviour
{
    // References plant model
    public GameObject plant;

    // Maximum time the plants spawn in
    public float maxTime = 8f;

    // Minimum time the plants spawn in
    public float minTime = 5;

    // Current game time
    private float time;

    // Time plant spawns
    private float spawnTime;

    // Limit where the plant spawns on Y axis
    private float spawnLimitY = 0.9483199F;

    // Limit where the plant spawns on X axis (right)
    private float spawnLimitXRight = 10.649f;

    // Limit where the plant spawns on X axis (left)
    private float spawnLimitXLeft = -7.462f;

    // Limit where the plant spawns on Z axis (front)
    private float spawnLimitZFront = -16.22f;

    // Limit where the plant spawns on Z axis (back)
    private float spawnLimitZBack = 1.9f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetRandomTime();
        time = minTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Counts time up
        time += Time.deltaTime;

        // If time is less than/equal to spawnTime, spawn a plant and set a random time
        if (time >= spawnTime)
        {
            SpawnTree();
            SetRandomTime();
        }
    }
    void SpawnTree()
    {
        // Spawns plant at random position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnLimitY, Random.Range(spawnLimitZBack, spawnLimitZFront));

        // Resets time
        time = 0;

        // Spawns in a plant
        Instantiate(plant, spawnPos, plant.transform.rotation);
    }

    void SetRandomTime()
    {
        // Sets random time between min and max
        spawnTime = Random.Range(minTime, maxTime);
    }
}
