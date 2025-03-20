
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Vector3 _lerpOffset;
    private Vector3 _targetPosition;
    void FixedUpdate()
    {
        _targetPosition = _player.position;

        transform.position = Vector3.Lerp(transform.position,_targetPosition + _offset, 0.1f);
    }
}
