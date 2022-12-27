using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField] private float speed;
    private float normalSpeed;

    [SerializeField] private GameObject bombSound;

    [SerializeField] private GameObject[] blood;

    private void Start()
    {
        normalSpeed = speed;
    }

    private void Update()
    {
        if (transform.position.x > 0) { speed = -normalSpeed; transform.localScale = new Vector3(-1, 1, 1); }

        else if (transform.position.x > 0) { transform.localScale = new Vector3(1, 1, 1); speed = normalSpeed; } 

        transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Player.instance.deathCount++;
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Bomb")
        {
            Instantiate(blood[Random.Range(0, blood.Length)], transform.position, Quaternion.identity);
            Instantiate(bombSound, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);

            //StartCoroutine(Death());
        }
    }

    private IEnumerator Death() 
    {
        yield return new WaitForSeconds(0.5f);

        Destroy(gameObject);
    }

}
