using UnityEngine;
using System.Collections;

public class BotSpawner : MonoBehaviour
{
    public GameObject botPrefab;
    public float spawnInterval = 4f;
    public float spawnRadius = 5f;

  

    private void Start()
    {
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
        float randomAngle = Random.Range(0f, Mathf.PI * 2f);

        Vector3 randomPosition = transform.position + new Vector3(Mathf.Cos(randomAngle), 0f, Mathf.Sin(randomAngle)) * spawnRadius;
        randomPosition.y = 0f;
        GameObject bot = Instantiate(botPrefab, randomPosition, Quaternion.identity);
        BotMovement botMovement = bot.GetComponent<BotMovement>();
        if (botMovement == null)
        {
            bot.AddComponent<BotMovement>();
        }
    }
}
