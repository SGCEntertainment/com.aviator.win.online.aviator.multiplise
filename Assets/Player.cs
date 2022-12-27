using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject pause;

    public static Player instance;

    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject weaponPos;

    private int health = 3;
    public int deathCount = 0;

    private Rigidbody2D rigid;

    [SerializeField] private TextMeshProUGUI hText;
    [SerializeField] private TextMeshProUGUI dText;

    [SerializeField] private GameObject sound, sound1;

    private void Start()
    {
        instance = this;
        rigid= GetComponent<Rigidbody2D>();
        Time.timeScale = 1f;
    }

    private void Update()
    {
        hText.text = health.ToString();
        dText.text = deathCount.ToString();

        if (health <= 0)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    public void Left()
    {
        transform.localScale = new Vector3(0.87f, 0.87f, 0.87f);
    }

    public void Right()
    {
        transform.localScale = new Vector3(-0.87f, 0.87f, 0.87f);
    }

    public void Shot()
    {
        Instantiate(bullet, weaponPos.transform.position, Quaternion.identity);
        Instantiate(sound, weaponPos.transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Zombie")
        {
            Destroy(collision.gameObject);
            health--;
            Instantiate(sound1, weaponPos.transform.position, Quaternion.identity);
        }

    }

    public void Pause()
    {
        Time.timeScale= 0f;
        pause.SetActive(true);  
    }

    public void Pauseoff()
    {
        Time.timeScale = 1f;
        pause.SetActive(false);
    }
}
