using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public Transform front;
    public GameObject hungryCat;
    public GameObject fullCat;

    public int type;
    float speed;
    float full;
    float energy = 0.0f;
    bool isFull = false;

    // Start is called before the first frame update
    void Start()
    {
        float x = Random.Range(-9.0f, 9.0f);
        float y = 30.0f;
        transform.position = new Vector2(x, y);

        if (type == 1)
        {
            speed = 0.05f;
            full = 5f;
        }
        else if (type == 2)
        {
            speed = 0.02f;
            full = 10f;
        }
        else if (type == 3)
        {
            speed = 0.1f;
            full = 5f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * speed;

        if (energy < full)
        {
            transform.position += Vector3.down * speed;

            if (transform.position.y < -16.0f)
            {
                GameManager.Instance.GameOver();
            }
        }
        else
        {
            if (transform.position.x > 0)
            {
                transform.position += Vector3.right * 0.05f;
            }
            else
            {
                transform.position += Vector3.left * 0.05f;
            }
            Destroy(gameObject, 3.0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            if (energy < full)
            {
                energy += 1.0f;
                Destroy(collision.gameObject);
                front.localScale = new Vector3(energy / full, 1.0f, 1.0f);

                if (energy == 5.0f)
                {
                    if (!isFull)
                    {
                        isFull = true;
                        hungryCat.SetActive(false);
                        fullCat.SetActive(true);
                        GameManager.Instance.AddScore();
                        Destroy(gameObject, 3.0f);
                    }
                }
            }
        }
    }
}
