using UnityEngine;
using UnityEngine.UI;

public class RaycastShooting : MonoBehaviour
{
    [SerializeField] float _damage;
    [SerializeField] float _range;
    [SerializeField] Transform _fpsCamera;
    [SerializeField] Image _aim;
    Target _target;

    private void FixedUpdate()
    {
            Shoot();
    }

    /// <summary>
    /// Call raycast, checed if reycast colision with target, give some damage him.
    /// </summary>
    private void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(_fpsCamera.position, _fpsCamera.forward, out hit))
        {
            _target = hit.transform.GetComponent<Target>();

            if (_target != null && Input.GetKeyDown(KeyCode.Mouse0))
            {
                _target.TakeDamage(_damage);
                Debug.Log($"Taget {_target.name} stay {_target.health} HP");
            }

            // ========== Dont work ==========
            void OnTriggerStay(Collider other)
            {
                if (other.gameObject.CompareTag("Target")) _aim.color = Color.red;
            }
            // ===============================
        }
    }
}