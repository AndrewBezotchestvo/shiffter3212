using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody _rb;

    [SerializeField] private float _speed;
    [SerializeField] private float _shuffleSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Text _distance;

    private Vector3 _movement;
    private bool _isGround;
    private bool _isJump;

    private void Start()
    {
        _movement = new Vector3(0, -1, _speed);
        _isGround = true;
        _isJump = false;
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _distance.text = Convert.ToString(Mathf.Round(transform.position.z));
        if (Input.GetKeyDown(KeyCode.Space) && _isGround && !_isJump)
        {
            //_isGround = false;
            //_rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _isJump = true;
            StartCoroutine(rotateCube());
        }
    }

    private void FixedUpdate()
    {
        _movement.z = _speed;

        if (Input.GetKey(KeyCode.D))
        {
            _movement.x = _shuffleSpeed;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _movement.x = -_shuffleSpeed;
        }
        else
        {
            _movement.x = 0;
        }

        if (_isJump)
        {
            Debug.Log("прыг скок");
            _movement.y = _jumpForce;
            _isJump = false;
        }
        if (_movement.y > 0)
        {
            _movement.y -= _jumpForce * 0.01f;
        }
        if (_movement.y < -2)
        {
            _movement.y = -2;
        }
        _rb.MovePosition(transform.position + _movement * Time.fixedDeltaTime);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            _isGround = true;
        }
    }


    IEnumerator rotateCube()
    {
        for (int i = 0; i <= 45; i++)
        {
            transform.rotation = Quaternion.Euler(i * 2, 0, 0);
            yield return new WaitForSeconds(0.001f);
        }
    }
}
