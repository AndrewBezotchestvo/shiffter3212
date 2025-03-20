using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnPlatform : MonoBehaviour
{
    [SerializeField] private Transform _player;

    [SerializeField] private Vector3 offset;

    void Update()
    {
        transform.position = new Vector3(_player.position.x + offset.x,
            offset.y,
            _player.position.z + offset.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
