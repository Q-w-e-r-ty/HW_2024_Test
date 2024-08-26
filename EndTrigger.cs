using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    private GameManager manager;

    // Start is called before the first frame update
    private void Awake()
    {
        manager = FindObjectOfType<GameManager>();

    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            manager.GameOver();
        }
    }
}
