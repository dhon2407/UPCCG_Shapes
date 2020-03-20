using System;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 1f;

        private Rigidbody2D _rigidBody;

        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            var moveVector = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
            _rigidBody.MovePosition((Vector2) transform.position + moveVector * (Time.deltaTime * moveSpeed));
        }
    }
}
