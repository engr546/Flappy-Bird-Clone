﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{

    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(GameManager.instance.ScrollSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.IsGameOver)
            rb2d.velocity = Vector2.zero;
    }

}
