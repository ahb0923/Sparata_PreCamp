using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    public GameObject food;

    private float shootSpeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MakeFood", 0f, shootSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float x = mousePos.x;

        if(x > 8.5f) { x = 8.5f; }
        if(x< -8.5f) { x = -8.5f; }

        transform.position = new Vector2(x, transform.position.y);
    }
    void MakeFood()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        Instantiate(food, new Vector2(x, y), Quaternion.identity);
    }
}
