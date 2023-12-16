using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float shootingInterval;

    public Vector3 bulletOffset;
    public float lastBulletTime;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            UpdateFiring();

        }
    }

    private void UpdateFiring()
    {
        if (Time.time - lastBulletTime > shootingInterval)
        {
            ShootBullet();
            lastBulletTime = Time.time;
        }
    }

    private void ShootBullet()
    {
        var bullet = Instantiate(bulletPrefab,transform.position +  bulletOffset, transform.rotation);
    }

}
