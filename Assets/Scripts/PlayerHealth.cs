using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 3;
    private int _currentHealth;

    [SerializeField] private Image[] _hearts;
    [SerializeField] private Sprite _fullHealth;
    [SerializeField] private Sprite _nullHealth;

    private Vector3 _respawnPoint;

    void Start()
    {
        _currentHealth = _maxHealth;
        _respawnPoint = transform.position;
        HealthBarController();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Damaged(1);
        }
    }

    public void Damaged(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            Die();
        }
        else
        {
            transform.position = _respawnPoint;
            HealthBarController();
        }
    }

    public void SetCheckpoint(Vector3 newPosition)
    {
        _respawnPoint = newPosition;
    }

    private void HealthBarController()
    {
        for (int i = 0; i < _hearts.Length; i++)
        {
            if (i < _currentHealth)
            {
                _hearts[i].sprite = _fullHealth;
            }
            else
            {
                _hearts[i].sprite = _nullHealth;
            }
        }
    }

    void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
