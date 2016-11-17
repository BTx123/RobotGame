﻿// https://unity3d.com/learn/tutorials/projects/survival-shooter/more-enemies

using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

    public GameObject Player;
    public GameObject Scrap;

    public bool aggro;
    public bool return_init;

    public int currHealth = 50;

    public float distance;
    public float distance_left;
    public float distance_right;
    public float initial_pos;
    public float max_follow_right;
    public float max_follow_left;
    public float x_coor;

    // Use this for initialization
    void Start ()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        //item_drop = GetComponent<Scrap>();
        distance_left = transform.position.x - 5;
        distance_right = transform.position.x + 5;
        initial_pos = transform.position.x;
        max_follow_right = distance_right + 5;
        max_follow_left = distance_left - 5;
        aggro = false;
        return_init = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if (currHealth <= 0)
        {
            print("Enemy killed!");
            Destroy(gameObject);
        }

        x_coor = transform.position.x;
        distance = Vector2.Distance(transform.position, Player.transform.position);

        if (return_init == true)
        {
            if (transform.position.x < initial_pos + 1f && transform.position.x > initial_pos - 1f)
            {
                return_init = false;
            }
            else
            {
                transform.LookAt(new Vector3(initial_pos, -5.5f, 0));
                transform.Rotate(0, -90, 0);
                if (transform.position.x > initial_pos)
                {
                    transform.Translate(-0.1f * Time.deltaTime, 0f, 0f);
                }
                else
                {
                    transform.Translate(0.1f * Time.deltaTime, 0f, 0f);
                }
            }
        }
        else if (Player.transform.position.x >= distance_left && Player.transform.position.x <= distance_right)
        {
            TurnToPlayer();
            aggro = true;

            if (distance < 2.5f)
            {
                transform.Translate(0, 0, 0);
            }

            else
            {
                transform.Translate(3f * Time.deltaTime, 0, 0);
                //Vector2 velocity = new Vector2((transform.position.x - Player.transform.position.x) * .4f, 0);
            }
        }

        if (aggro == true && !(Player.transform.position.x >= distance_left && Player.transform.position.x <= distance_right))
        {
            TurnToPlayer();
            if (distance < 2f)
            {
                transform.Translate(0, 0, 0);
            }
            else
            {
                transform.Translate(4f * Time.deltaTime, 0, 0);
            }

            if (distance > 6)//transform.position.x >= max_follow_right || transform.position.x <= max_follow_left)
            {
                aggro = false;
                return_init = true;
                //transform.Rotate(-90, 0, 0);
            }
        }

        else
        {
            if ((transform.position.x < distance_left || transform.position.x > distance_right) && return_init == false && aggro == false)
            {
                transform.Rotate(0, -90, 0, Space.World);
            }
            transform.Translate(.03f, 0, 0);

            Vector3 pos = transform.position;
            pos.z = 0;
            transform.position = pos;
        }
    }

    void TurnToPlayer()
    {
        transform.LookAt(new Vector3(Player.transform.position.x, -5.5f, 0));

        transform.Rotate(0, -90, 0);
        //GetComponent<Rigidbody2D> ().velocity = new Vector2 (2.5f * Time.deltaTime, 0);
    }

    void FollowPlayer()
    {
        
    }

    // Called when player hits enemy, subtracts health from enemy and plays damaged animation
    void Damage(int damage)
    {
        currHealth -= damage;
        // TODO: red flash animation
        // gameObject.GetComponent<Animation>().Play("DamageRedFlash");
    }
}
