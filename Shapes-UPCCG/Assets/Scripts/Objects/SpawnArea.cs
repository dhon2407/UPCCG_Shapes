using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

namespace Objects
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class SpawnArea : MonoBehaviour
    {
        [SerializeField, Range(2, 5)] private float timeToSpawn = 2f;
        [SerializeField] private Spawner spawner = null;
        

        private BoxCollider2D _box;
        private (float min, float max) _spawnRange;

        private void Awake()
        {
            _box = GetComponent<BoxCollider2D>();
            var bounds = _box.bounds;

            _spawnRange = (bounds.min.x, bounds.max.x);

            if (spawner)
                StartCoroutine(StartSpawning());
        }

        private IEnumerator StartSpawning()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(2, timeToSpawn));
                spawner.Spawn(new Vector2(Random.Range(_spawnRange.min, _spawnRange.max), transform.position.y));
            }
        }
    }
}