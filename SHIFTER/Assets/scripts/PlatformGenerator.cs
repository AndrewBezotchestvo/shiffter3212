using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlatformGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _spawnCube;

    private List<GameObject> _spawnedCubes;
    private List<GameObject> _spawnedCubesRow;

    private Vector3 offset;

    public void DestroyPlatform()
    {
        StartCoroutine(DropAllCubes());
    }

    public Vector3 CubesGenerator(Vector3 startPosition, int rows, int columns)
    {
        _spawnedCubes = new List<GameObject>();
        _spawnedCubesRow = new List<GameObject>();

        Vector3 lastPosition = startPosition;

        for (int i = 0; i < columns; i++)
        {
            _spawnedCubesRow.Clear();

            for (int j = 0; j < rows; j++) 
            {
                GameObject newCube = Instantiate(_spawnCube);
                offset = new Vector3(j, 0, i);
                newCube.transform.position = startPosition + offset;
                lastPosition = newCube.transform.position;

                _spawnedCubesRow.Add(newCube);
                _spawnedCubes.Add(newCube);
            }

            int RandomCube = Random.Range(0, rows);
            int RandomAction = Random.Range(0, 2);

            if (RandomAction == 0)
            {
                _spawnedCubesRow[RandomCube].GetComponent<CubeController>().DropCubeDown();
            }
            else
            {
                _spawnedCubesRow[RandomCube].GetComponent<CubeController>().PullCubeUp();
            }

        }
        return lastPosition;
    }


    IEnumerator DropAllCubes() 
    {
        foreach (GameObject cube in _spawnedCubes)
        {
            if (cube != null)
            {
                cube.GetComponent<CubeController>().DropCubeDown();
                
            }
            yield return new WaitForSeconds(0.05f);
        }
    }
}
