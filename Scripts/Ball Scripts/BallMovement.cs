using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LukasScripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class BallMovement : MonoBehaviour
    {
        public delegate void OnBallDied();
        public static event OnBallDied onBallRestart;

        [SerializeField]
        [Header("Default speed was 3.2")]
        private float speed = 5f;

        [SerializeField] [Header("default = 2.5")]
        private float swipeSpeed = 10f;

        private float _minDist = -0.8f;

        private Transform _mTransform;

        private GameManager _gameManager;
        private SoundManager _soundManager;

        private Vector3 _movement;
        private Vector3 _swipe;
        private Rigidbody _rb;

        

        private void Start()
        {
    
            _rb = GetComponent<Rigidbody>();
            _mTransform = this.transform;
            _movement = transform.position;
            _soundManager = SoundManager.instance;
            _gameManager = GameManager.instance;
        }

        private void Update() => CheckDistanceToRestartGame();


        private void FixedUpdate() => Move();


        private void CheckDistanceToRestartGame()
        {
            if(_mTransform.position.y < -0.20f)
            {
                _rb.drag = 5f;
                _rb.angularDrag = 999f;
            }

            if (_mTransform.position.y <= _minDist)
            {
                _soundManager.PlayGameOverClip();
                onBallRestart?.Invoke();
                gameObject.SetActive(false);
               // _gameManager.ReloadGame();
               
            }
        }

        private void Move()
        {
            _movement = transform.position;
            _movement.z += speed * Time.fixedDeltaTime;
            _rb.MovePosition(_movement);

      
        }

        public void LeftTap()=> transform.Translate(Vector3.left * swipeSpeed * Time.deltaTime);
        
        public void RightTap()=> transform.Translate(Vector3.right * swipeSpeed * Time.deltaTime);

        
     


       
    }


}