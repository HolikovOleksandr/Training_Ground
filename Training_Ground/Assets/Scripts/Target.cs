using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] float _health;

    public void TakeDamage(float amound)
    {
        _health -= amound;
        if(_health <= 0) Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
