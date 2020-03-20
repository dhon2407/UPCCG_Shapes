using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Objects
{
    public class Spawner : MonoBehaviour
    {
        private static List<GameObject> _pool = new List<GameObject>();
        
        [SerializeField] private List<GameObject> availableShapes = null;
        [SerializeField] private int maxPoolCount = 10;
        
        
        public void Spawn(Vector2 position)
        {
            if (availableShapes.Count > 0)
            {
                if (IsFull())
                    Instantiate(availableShapes[Random.Range(0, availableShapes.Count)], position,
                        Quaternion.identity);
                else
                {
                    var freeObj = GetFreeObject();
                    if (!freeObj) return;
                    
                    freeObj.SetActive(true);
                    freeObj.transform.position = position;
                }
            }
            else
                throw new UnityException("No available shapes to spawn.");
        }

        private static GameObject GetFreeObject()
        {
            return _pool.FirstOrDefault(gObj => !gObj.activeSelf);
        }

        private static bool IsFull()
        {
            return _pool.All(gameObject => gameObject.activeSelf);
        }
    }
}