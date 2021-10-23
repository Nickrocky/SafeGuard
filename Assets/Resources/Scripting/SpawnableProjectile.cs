using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnableProjectile : MonoBehaviour
{
    public GlobalGameHandler gameHandler;
    public GameObject heartLocation;
    public float speed;
    public BulletType bulletType;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        setSpeedFromType();

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Fuckyourself");
        transform.position += transform.up * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if(collision.gameObject.name == "Shield")
        {
            var isShielding = collision.gameObject.GetComponent<PlayerController>().isShielding;
            if (isShielding)
            {
                Destroy(gameObject);
            }  
        }
        if(collision.gameObject.name == "Level") { Destroy(gameObject);}
        if(collision.gameObject.name == "Heart") {
            gameHandler.health -= getDamageFromType();
            Destroy(gameObject); 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.name.StartsWith("Orb")) return;
        var player = GameObject.Find("Shield");
        if (player.GetComponent<PlayerController>().bulletCharges < 5)
        {
            Destroy(gameObject);
            player.GetComponent<PlayerController>().bulletCharges += 1;
        }
    }

    private int getDamageFromType()
    {
        switch (bulletType)
        {
            case BulletType.charged:
                return 2;
            case BulletType.basic:
            case BulletType.speedy:
            default:
                return 1;
        }
    }

    private void setSpeedFromType()
    {
        speed = ((float) ((int)bulletType));
    }
}
public enum BulletType : int
{
    basic = 5,
    charged = 7,
    speedy = 10,

}
