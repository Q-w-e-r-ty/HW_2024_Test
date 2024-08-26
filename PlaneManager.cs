using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlaneManager : MonoBehaviour
{
    [SerializeField] private GameObject NewPlane;
    public float spawnWait;
    private float spawnMostWait = 4f;
    private float spawnLeastWait = 3f;
    public int startWait;
    public bool stop;
    private GameObject currentPlane;
    private GameObject temp;
    int randdirection;

    // Start is called before the first frame update
    void Start()
    {
        currentPlane = Instantiate(NewPlane, Vector3.zero, Quaternion.identity);
        StartCoroutine(WaitSpawner());
    }

    // Update is called once per frame
    void Update()
    {
        spawnWait = Random.Range(this.spawnLeastWait, this.spawnMostWait);
    }
    IEnumerator WaitSpawner()
    {
        yield return new WaitForSeconds(startWait);

        while (!stop)
        {
            Vector3 spawnPosition = GetRandomDirection();

            GameObject newPlane = Instantiate(NewPlane, spawnPosition, Quaternion.identity);

            Destroy(currentPlane, 2f);

            currentPlane = newPlane;

            yield return new WaitForSeconds(spawnWait);
        }
    }

    Vector3 GetRandomDirection()
    {
        int randDirection = Random.Range(0, 4);

        switch (randDirection)
        {
            case 0: // Left
                return currentPlane.transform.position + new Vector3(-30, 0, 0);
            case 1: // Right
                return currentPlane.transform.position + new Vector3(30, 0, 0);
            case 2: // Up
                return currentPlane.transform.position + new Vector3(0, 0, 30);
            case 3: // Down
                return currentPlane.transform.position + new Vector3(0, 0, -30);
            default:
                return currentPlane.transform.position;
        }
    }
}
