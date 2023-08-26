using System;
using System.Collections;
using GameLogic.Services.Input;
using UnityEngine;
using Zenject;

namespace GameLogic.Systems.Analyze
{
    public class UpdateTester : MonoBehaviour
    {
        private IInputService _inputService;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float movementSpeed;
        private bool _isStop;
        private float _fixedUpdateFramesCount;

        [Inject]
        private void Construct(IInputService inputService) =>
            _inputService = inputService;

        private void Start() =>
            Application.targetFrameRate = int.MaxValue;

        private void FixedUpdate() => 
            _rigidbody.velocity = new Vector2(-1 * movementSpeed, 0);

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.name == "Stopper")
                Debug.Log(Time.time);
        }
    }
}