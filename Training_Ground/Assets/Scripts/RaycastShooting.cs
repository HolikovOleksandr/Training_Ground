using UnityEngine;

public class RaycastShooting : MonoBehaviour
{
    [SerializeField] float _damage;
    [SerializeField] float _range;
    [SerializeField] Transform _fpsCamera;
    [SerializeField] KeyCode _fireKey;

    private void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if(Input.GetKeyDown(_fireKey))
        {
            RaycastHit hit;

            if(Physics.Raycast(_fpsCamera.position, _fpsCamera.forward, out hit))
            {
                Target target = hit.transform.GetComponent<Target>();

                if(target != null) target.TakeDamage(_damage);
            }
        }    
    }
}
