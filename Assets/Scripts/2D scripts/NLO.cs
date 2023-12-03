using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NLO : MonoBehaviour{
    public bool isRun = false;

    private void Update(){
        if (!isRun) return;
        transform.position += new Vector3(1, 0, 0);
        if (transform.position.x >= 900) Destroy(gameObject);
    }
    public void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.layer == 9){
            isRun = true;
            Destroy(collision.gameObject);
        }
    }
}