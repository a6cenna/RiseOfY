using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private SpriteRenderer sr;
    private Collider2D col;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
        anim = GameObject.FindGameObjectWithTag("Boss").GetComponent<Animator>();
        sr.enabled = false;
        col.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SpikeS()
    {
        sr.enabled = true;
        col.enabled = true;
    }
    public void SpikeF()
    {
        sr.enabled = false;
        col.enabled = false;
    }
}
