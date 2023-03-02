using UnityEngine;

public class Target : MonoBehaviour
{
    public float health;

    public void TakeDamage(float amound)
    {
        health -= amound;
        if (health <= 0) Destroy(gameObject);
        Debug.Log($"Taget {name} stay {health} HP");
    }
}
