using UnityEngine;
using System.Collections;

public class BotSpawner : MonoBehaviour
{
    public GameObject botPrefab;
    public float spawnInterval = 2f;
    public float spawnRadius = 5f;

    private void Start()
    {
        // Start spawning bots
        StartCoroutine(SpawnBotRoutine());
    }

    IEnumerator SpawnBotRoutine()
    {
        while (true)
        {
            SpawnBot();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnBot()
    {
        // Calculate random angle
        float randomAngle = Random.Range(0f, Mathf.PI * 2f);

        // Calculate spawn position on the circumference of the circle
        Vector3 randomPosition = transform.position + new Vector3(Mathf.Cos(randomAngle), 0f, Mathf.Sin(randomAngle)) * spawnRadius;
        // Ensure the bot is grounded (adjust this according to your game's needs)
        randomPosition.y = 0f;

        // Instantiate the bot prefab at the calculated position without parenting it to any GameObject
        GameObject bot = Instantiate(botPrefab, randomPosition, Quaternion.identity);

        // Attach the BotMovement script to the instantiated bot GameObject
        BotMovement botMovement = bot.GetComponent<BotMovement>();
        if (botMovement == null)
        {
            bot.AddComponent<BotMovement>();
        }
    }
}
