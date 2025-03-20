using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{   

    private Rigidbody _rb;

    public void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void DropCubeDown()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.isKinematic = false;
        Invoke("DestroyCube", 3f);
    }

    public void DestroyCube()
    {
        Destroy(gameObject);
    }
    public void PullCubeUp()
    {
        StartCoroutine(pullUp());
    }
    IEnumerator pullUp()
    {
        for (int i = 0; i < 10; i++)
        {
            transform.position = new Vector3(transform.position.x, 
                transform.position.y + 0.05f, 
                transform.position.z);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
