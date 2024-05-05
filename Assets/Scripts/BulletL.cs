using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletL : MonoBehaviour
{
    private float speed = 10;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

    }
}
