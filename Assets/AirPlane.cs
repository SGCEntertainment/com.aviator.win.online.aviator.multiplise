using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPlane : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    [SerializeField] private float speed;
    int current;

    [SerializeField] private GameObject bomb;

    private void Start()
    {
        current = 0;
        StartCoroutine(Spawn());
    }

    private void Update()
    {
        if (current == 1) transform.localScale = new Vector3(0.82f, 0.82f, 0.82f);

        else if (current == 0) transform.localScale = new Vector3(-0.82f, 0.82f, 0.82f);


        if (transform.position != points[current].position)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[current].position, speed * Time.deltaTime); 
        }

        else current = (current + 1) % points.Length;
    }

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(Random.Range(3, 6));

        Instantiate(bomb, transform.position, Quaternion.identity);

        StartCoroutine(Spawn());
    }
}
