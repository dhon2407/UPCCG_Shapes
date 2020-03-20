using System;
using Objects;
using Shapes;
using UnityEngine;

namespace Player
{
    public class ShapePlayer : MonoBehaviour
    {
        [SerializeField] private Shape currentShape = Shape.Square;

        private void OnCollisionEnter2D(Collision2D other)
        {
            var col = other.collider;
            
            if (col != null && col.CompareTag("FallingObjects"))
            {
                var fObj = col.GetComponent<FallingObjects>();
                
                if (fObj && fObj.Shape == currentShape)
                    fObj.Hit();
                else
                    Debug.Log("Not same shape.");
            }
        }
    }
}