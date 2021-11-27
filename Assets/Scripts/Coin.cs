using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    Transform coinTransform;

    // Start is called before the first frame update
    void Start()
    {
        coinTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        coinTransform.Rotate(Vector3.up * 0.5f);
    }
}
