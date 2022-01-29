using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float range;
    public float fireIntervalTime;
    public float projectileSpeed;

    public GameObject bullet;
    private float _lastFire;
    private Vector3 _shootingPosition;

    public void Start()
    {
        var shotPos = GameObject.FindWithTag("firing_location");
        // var shotPos = this
        //     .GetComponents<GameObject>()
        //     .First(src => src.tag.Equals("firing_location"));
        _shootingPosition = shotPos.transform.position;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.realtimeSinceStartup - _lastFire < fireIntervalTime)
        {
            return;
        }
     
       
        print("Pass");
        
        var position = transform.position;
        var findGameObjectsWithTag = GameObject.FindGameObjectsWithTag("enemy");
        foreach (var enemy in findGameObjectsWithTag)
        {
            if (Vector3.Distance(position, enemy.transform.position) > range)
            {
                continue;
            }

            Fire(enemy);
            _lastFire = Time.deltaTime;
            break;
        }
    }

    private void Fire(GameObject at)
    {
        GameObject projectile = Instantiate(bullet, _shootingPosition, Quaternion.identity);

        Vector3 fireDirection = at.transform.position - _shootingPosition;
        projectile.transform.forward = fireDirection;
        projectile.GetComponent<BulletController>().Speed = projectileSpeed;
    }
}
