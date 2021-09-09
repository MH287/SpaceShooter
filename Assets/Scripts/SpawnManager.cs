using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Camera Camera;
    public GameObject Player;
    public GameObject[] MeteoritPreFabs;

    public float SpawnRateMinimum = 0.5f;
    public float SpawnRateMaximum = 1.5f;

    public float MeteoritRotationMinimum = 0.5f;
    public float MeteoritRotationMaximum = 1.5f;

    public float MeteoritSpeedMinimum = 1;
    public float MeteoritSpeedMaximum = 3;

    private float _nextSpawnTime;

    private void DetermineNextSpawnTime()
    {
        _nextSpawnTime = Time.time + Random.Range(SpawnRateMinimum, SpawnRateMaximum);
    }

    private void Update()
    {
        if (Time.time >= _nextSpawnTime)
        {
            SpawnMeteorit();
            DetermineNextSpawnTime();
        }
    }

    private void Start ()
    {
        DetermineNextSpawnTime();
    }

    private void SpawnMeteorit()
    {
        var prefabIndexToSpawn = Random.Range(0, MeteoritPreFabs.Length);
        var prefabToSpawn = MeteoritPreFabs[prefabIndexToSpawn];
        var Meteorit = Instantiate(prefabToSpawn, transform);

        // TODO 1: Position zufällig bestimmen

        var placeVertical = Random.Range(0, 2) == 0;
        float yPosition;
        float xPosition;

        if (placeVertical)
        {
            var halfWidth = Camera.orthographicSize * Camera.aspect;
            xPosition = Random.Range(-halfWidth, halfWidth);


            var sign = Random.Range(0, 2) == 0 ? -1 : 1;

            /*int sign;
            if (Random.Range(0, 2) == 0)
            {
                sign = -1;
            }
            else
            {
                sign = 1;
            }*/

            yPosition = sign * (Camera.orthographicSize + 2);
        }
        else
        {
            var halfHeight = Camera.orthographicSize;
            yPosition = Random.Range(-halfHeight, halfHeight);

            var sign = Random.Range(0, 2) == 0 ? -1 : 1;
            xPosition = sign * (Camera.orthographicSize * Camera.aspect + 2);
        }

        var position = new Vector3(xPosition, yPosition);
        Meteorit.transform.position = position;

        // TODO 2: Meteorit in Richtung des Spielers schubsen

        var direction = position - Player.transform.position;
        var speed = Random.Range(MeteoritSpeedMinimum, MeteoritSpeedMaximum);

        var rigidbody = Meteorit.GetComponent<Rigidbody2D>();

        rigidbody.AddForce(-direction.normalized * speed, ForceMode2D.Impulse);

        // TODO 3: Meteorit drehen

        var rotation = Random.Range(MeteoritRotationMinimum, MeteoritRotationMaximum);

        rigidbody.AddTorque(rotation);
        
    }
}
