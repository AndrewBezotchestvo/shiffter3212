using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    [SerializeField] private GameObject Platform;

    private Vector3 LastPosition = Vector3.zero;

    private List<GameObject> _platforms = new List<GameObject>();

    [SerializeField] private Transform _player;

    private void Start()
    {
        _platforms = new List<GameObject>();
    }

    private void Update()
    {
        if (LastPosition.z <= _player.position.z + 12f)
        {
            SpawnPlatform();
        }

        if (_platforms.Count >= 4)
        {
            _platforms[0].GetComponent<PlatformGenerator>().DestroyPlatform();
            _platforms.RemoveAt(0);
        }
    }
    private void SpawnPlatform()
    {
        GameObject newPlatform = Instantiate(Platform);
        newPlatform.transform.position = LastPosition;
        LastPosition = newPlatform.GetComponent<PlatformGenerator>().CubesGenerator(new Vector3(0, 0, LastPosition.z + 1), 3, 8);
        _platforms.Add(newPlatform);
    }

}
