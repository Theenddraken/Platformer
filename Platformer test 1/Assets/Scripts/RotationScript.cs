﻿using UnityEngine;

public class RotationScript : MonoBehaviour
{
    public float speed = 5f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, speed);
    }
}
