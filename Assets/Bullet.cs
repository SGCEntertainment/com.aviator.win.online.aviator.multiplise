using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    private float normalSpeed;
    [SerializeField] private float lifeTime = 1.5f;

    private void Start()
    {
        normalSpeed = speed;

        Destroy(gameObject, lifeTime);
    }
    private void Update()
    {
        if (Player.instance.transform.localScale.x >= 0) speed = normalSpeed;

        else if (Player.instance.transform.localScale.x <= 0) speed = 15.5f;

        transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag == "Stop")
        {
            Destroy(gameObject);
        }
    }
}
