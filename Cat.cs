using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    [SerializeField] float movespeed;
    [SerializeField] float full;
    float energy = 0.0f;
    bool isFull = false;

    public Transform front;
    public GameObject fullCat;
    public GameObject hungryCat;

    // Start is called before the first frame update
    void Start()
    {
        

        float x = Random.Range(-9.0f, 9.0f);
        float y = 30.0f;
        transform.position = new Vector2(x, y);
    }

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
    // Update is called once per frame
    void Update()
    {
        if(energy < full)
        {
            transform.position += Vector3.down * movespeed;

            if(transform.position.y < -16.0f)
            {
                GameManager.Instance.GameOver();
            }

        }
        else
        {
            if(transform.position.x > 0)
            {
                transform.position += Vector3.right*movespeed*2;
            }
            else
            {
                transform.position += Vector3.left*movespeed*2;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            if (energy < full)
            {
                energy += 1.0f;
                front.localScale = new Vector3(energy / full, 1.0f, 1.0f);
                Destroy(collision.gameObject);
                if(energy == full)
                {
                    isFull = true;
                    if (isFull)
                    {
                        hungryCat.SetActive(false);
                        fullCat.SetActive(true);
                        Destroy(gameObject, 3.0f);
                        GameManager.Instance.AddScore();
                    }
                }
            }
            else
            {
                hungryCat.SetActive(false);
                fullCat.SetActive(true);
            }
        }
    }
    /*
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }*/
}
