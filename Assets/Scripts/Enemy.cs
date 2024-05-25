using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    public GameObject coinsOnDeath;
    private int valueOfCoins = 20;
    public float maxHealth = 100f;
    public float currentHealth;
  
    void Start()
    {
        currentHealth = maxHealth;
        coinsOnDeath = Resources.Load<GameObject>("Prefabs/CoinsOnDeath");
        Debug.Log(coinsOnDeath);
        if (coinsOnDeath)
        {
            coinsOnDeath.GetComponent<TextMeshPro>().text = valueOfCoins.ToString() + " coins";
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GameObject gameManager = GameObject.Find("GameManager");
        Counter counter = gameManager.GetComponent<Counter>();
        if (counter != null)
        {
            counter.IncrementCount();
        }
        GameManagerScript.coins += valueOfCoins;
        if (coinsOnDeath)
        {
            Instantiate(coinsOnDeath, transform.localPosition, Camera.main.transform.rotation);
        }
        Destroy(gameObject);
    }
}