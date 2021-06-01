﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4.0f;

    private Player _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
      
        if(transform.position.y < -5.5f)
        {
            float randomX = Random.Range(-10f, 10f);
            transform.position = new Vector3(randomX, 7, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Player")
        {
            if (_player != null)
            {
                _player.Damage();
            }
          
            Destroy(this.gameObject);
        }
       
        else if (other.tag == "Laser")
        {
            Destroy(this.gameObject);
            if (_player != null)
            {
                _player.AddScore(10);
            }
            Destroy(other.gameObject);
        }
    }
}
