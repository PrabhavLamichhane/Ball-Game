using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LukasScripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class BallBounce : MonoBehaviour
    {
        [SerializeField]
        private float fallVelocity = 5f;

        [SerializeField]
        private float jumpForce = 5f;

        [SerializeField]
        private float jumpVelocity = 5.5f;

        private Rigidbody _rb;

        private LayerMask _checkForGround;
        private Transform _myTransform;

        private bool _canJump;
        private SoundManager _soundManager;

        [SerializeField]
        private bool canPlayFX = true;

        private void Awake()
        {
          //  _soundManager = SoundManager.instance;
            _rb = GetComponent<Rigidbody>();
            _myTransform = transform;
           // _checkForGround = ~(1 << 9 | 1<< 10);
        }

        #region Fixed Update
        private void FixedUpdate()
        {
         
            if (_canJump)
            {
                _canJump = false;
               
                JumpWithVelocity();
            }

            CheckVelocity();
        }

        private bool OnGround()
        {
            Vector3 origin = _myTransform.position;
            origin.y += 0.4f;
            Vector3 direction = -Vector3.up;
            float distance = 0.5f;

            RaycastHit hit;

            if (Physics.Raycast(origin, direction, out hit, distance, _checkForGround))
            {
                Vector3 targetPoint = hit.point;

                _myTransform.position = targetPoint;

                return true;
            }

            return false;
        }

        #endregion

        private void Jump()
        {
           _rb.AddForce(Vector3.up * jumpForce , ForceMode.Impulse);      
        }

        private void JumpWithVelocity()
        {
            StartCoroutine(PlayJumpSound(0.2f));
            _rb.velocity = new Vector3(_rb.velocity.x, jumpVelocity, _rb.velocity.z);
        }

        private void CheckVelocity()
        {

            if (_rb.velocity.y > 0)
            {
                _rb.drag = fallVelocity;
                _rb.angularDrag = 99f;
            }
            else
            {
                _rb.drag = 0;
                _rb.angularDrag = 0.05f;
            }
        }


        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag(TagManager.Platform))
            {
                //  Jump();
                _canJump = true;
            }
        }

        private IEnumerator PlayJumpSound(float t)
        {
            yield return new WaitForSeconds(t);
           
            if (canPlayFX)
            {
                if (SoundManager.instance == null)
                {
                    SoundManager sound = FindObjectOfType<SoundManager>();
                    sound.PlayJumpSound();
                }
                else
                {
                    SoundManager.instance.PlayJumpSound();
                }
            }
        }
    }
}
