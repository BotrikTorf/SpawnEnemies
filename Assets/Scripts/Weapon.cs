using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private int _damage = 10;
    [SerializeField] private int _range = 100;
    [SerializeField] private Camera _camera;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            Shoot();
    }

    private void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, _range))
        {
            Enemy enemy = hit.transform.GetComponent<Enemy>();

            if (enemy != null)
                enemy.TakeDamege(_damage);
        }
    }
}
