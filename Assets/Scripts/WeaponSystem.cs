using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    public Transform[] SpawnPoints;
    public Bullet BulletPreFab;
    public float FireRate = 1f;
    public AudioSource SoundEffect;

    private float _fireRateCounter;

    private void Update()
    {
        _fireRateCounter += Time.deltaTime;
    }

    public void Fire()
    {
        if(_fireRateCounter >= FireRate)
        {
            _fireRateCounter = 0;

            SoundEffect.Play();

            foreach(var spawnPoint in SpawnPoints)
            {
                Instantiate(BulletPreFab, spawnPoint);
            }
        }
    }
}
