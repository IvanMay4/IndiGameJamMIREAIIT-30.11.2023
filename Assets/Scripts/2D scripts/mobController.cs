using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mobController : MonoBehaviour
{
    public int health;
    public int damage;
    public float movementSpeed;
    public bool isStopped;
    public float damageCooldown;
    void Update()
    {
        if (!isStopped)
        {
            transform.Translate(new Vector3(movementSpeed * -1, 0, 0));
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            StartCoroutine(Attack(collision));
            isStopped = true;
        }
    }

    IEnumerator Attack(Collider2D collision)
    {
        if (collision == null)
        {
            isStopped = false;
        }
        else
        {
            collision.gameObject.GetComponent<Controller>().ReceiveDamage(damage);
            yield return new WaitForSeconds(damageCooldown);
            StartCoroutine(Attack(collision));
        }
    }

    public void ReceiveDamage(int Damage)
    {
        if (health - Damage <= 0)
        {
            transform.parent.GetComponent<SpawnPoint>().mobs.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
        else
        {
            health = health - Damage;
        }
    }
    
    
}
