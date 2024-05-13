using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController Instance;
    private float magnitude = .5f;
    public string cameraToShakeName;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    IEnumerator Shake(float durationShake)
    {
        Vector3 OriginalPosition = transform.position;
        float timeShake = 0f;
        while (timeShake < durationShake)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;
            transform.position = new Vector3(x, y, -10);
            timeShake += Time.deltaTime;
            yield return null;

        }
        transform.position = OriginalPosition;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartShake(.5f);
        }
    }
    public void StartShake(float durationShake)
    {
        StartCoroutine(Shake(durationShake));
    }
}
