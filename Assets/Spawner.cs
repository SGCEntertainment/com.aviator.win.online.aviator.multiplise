using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] zombies;
    [SerializeField] private GameObject[] pos;


    private void Start()
    {
       StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(Random.Range(1, 3));

        Instantiate(zombies[Random.Range(0, zombies.Length)], pos[Random.Range(0, pos.Length)].transform.position, Quaternion.identity);

        StartCoroutine(Spawn());
    }
}
