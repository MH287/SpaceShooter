using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MeteoritController : MonoBehaviour
{
    public float Damage = 1f;
    public int Points = 10;
    public int MaximumHealth = 3;
    public int CurrentHealth;

    public GameObject ExplosionPreFab;

    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();

        CurrentHealth = MaximumHealth;

        Destroy(gameObject, 30f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var playerController = other.GetComponent<PlayerController>();

            playerController.TakeDamage(Damage);

            Instantiate(ExplosionPreFab, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;

        if (CurrentHealth <= 0)
        {
            _gameManager.AddPoints(Points);
            Destroy(gameObject);
        }
    }
}   

