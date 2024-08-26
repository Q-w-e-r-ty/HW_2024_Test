using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    [SerializeField] private int scoreValue = 5;
    private GameManager manager;
    // Start is called before the first frame update
    private void Awake()
    {
        manager = FindObjectOfType<GameManager>();
        Debug.Log("Cry");
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            manager.ModifyScore(scoreValue);
            gameObject.SetActive(false);
            //Debug.Log("Score Modified");
        }
    }
}
