using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    private float minimum = 1.0f;
    private float magSpeed = 10.0f;
    private float magnification = 0.07f;

    // Start is called before the first frame update
    void Start()
    {
        // nop
    }

    // Update is called once per frame
    void Update()
    {
        // 周期的に拡大縮小
        float size = minimum + Mathf.Sin(Time.time * magSpeed) * magnification;
        transform.localScale = new Vector3(size, transform.localScale.y, size);
    }
}
