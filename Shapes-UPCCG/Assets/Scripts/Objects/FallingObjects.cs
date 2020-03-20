using System;
using Shapes;
using UnityEngine;

namespace Objects
{
    public class FallingObjects : MonoBehaviour
    {
        [SerializeField] private Shape shape;

        public Shape Shape => shape;
        
        public void Hit()
        {
            Debug.Log($"{name} is hit!");
            gameObject.SetActive(false);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider && other.collider.CompareTag("Ground"))
                gameObject.SetActive(false);
        }
    }
}