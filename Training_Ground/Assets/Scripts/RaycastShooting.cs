using UnityEngine;
using UnityEngine.UI;

public class RaycastShooting : MonoBehaviour
{
    [SerializeField] float _damage;
    [SerializeField] float _range;
    [SerializeField] Transform _fpsCamera;
    [SerializeField] Image _aim;
    Target _target;

    private void Update()
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

            if (_target != null)
            {
                _aim.color = Color.red;

                if (Input.GetKeyDown(KeyCode.Mouse0))
                    _target.TakeDamage(_damage);

            }
            else _aim.color = Color.white;
        }

    }
}
