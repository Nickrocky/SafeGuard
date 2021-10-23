using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GlobalGameHandler gameHandler;

    public int bulletCharges;

    public GameObject playerBullet;
    public GameObject playerSpawnPoint;
    public SpriteRenderer heartRenderer;
    public Sprite spriteRenderer;
    public Sprite shield;
    public Sprite deflector;
    public Sprite fullHeart, threeQuarterHeart, halfHeart, quarterHeart;
    public bool isShielding;
    public GameObject BulletIndicator1, BulletIndicator2, BulletIndicator3, BulletIndicator4, BulletIndicator5;
    // Start is called before the first frame update
    void Start()
    {
        bulletCharges = 0;
        isShielding = true;
    }

    // Update is called once per frame
    void Update()
    {
        updateRendererForBulletCharges();
        updateHeartRenderer();
        checkForShieldingAndUpdateSprite();
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePosition - transform.position);
        playerSpawnPoint.transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePosition - transform.position);
        playerShoot();
        awwShiii();
    }

    private void awwShiii()
    {
        if (isShielding)
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
        else
        {
            if(bulletCharges == 5)
            {
                gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
            else
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
                gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            }
        }
    }

    private void playerShoot()
    {
        if (isShielding) return;
        if (Input.GetMouseButtonDown(0) && bulletCharges >= 1)
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            var newBullet = Instantiate(playerBullet);
            newBullet.transform.rotation = gameObject.transform.rotation;
            newBullet.transform.position = playerSpawnPoint.transform.position;
            bulletCharges -= 1;
        }
    }

    private void checkForShieldingAndUpdateSprite()
    {
        if(Input.GetMouseButtonDown(1))
        {
            isShielding = !isShielding; 
        }
        if (isShielding) { GetComponent<SpriteRenderer>().sprite = shield; }
        else { GetComponent<SpriteRenderer>().sprite = deflector; }
    }

    private void updateRendererForBulletCharges()
    {
        switch (bulletCharges)
        {
            case 1:
                BulletIndicator1.active = true;
                BulletIndicator2.active = false;
                BulletIndicator3.active = false;
                BulletIndicator4.active = false;
                BulletIndicator5.active = false;
                break;
            case 2:
                BulletIndicator1.active = true;
                BulletIndicator2.active = true;
                BulletIndicator3.active = false;
                BulletIndicator4.active = false;
                BulletIndicator5.active = false;
                break;
            case 3:
                BulletIndicator1.active = true;
                BulletIndicator2.active = true;
                BulletIndicator3.active = true;
                BulletIndicator4.active = false;
                BulletIndicator5.active = false;
                break;
            case 4:
                BulletIndicator1.active = true;
                BulletIndicator2.active = true;
                BulletIndicator3.active = true;
                BulletIndicator4.active = true;
                BulletIndicator5.active = false;
                break;
            case 5:
                BulletIndicator1.active = true;
                BulletIndicator2.active = true;
                BulletIndicator3.active = true;
                BulletIndicator4.active = true;
                BulletIndicator5.active = true;
                break;
            default:
                BulletIndicator1.active = false;
                BulletIndicator2.active = false;
                BulletIndicator3.active = false;
                BulletIndicator4.active = false;
                BulletIndicator5.active = false;
                break;
        }
    }

    private void updateHeartRenderer()
    {
        switch (gameHandler.health)
        {
            case 4:
                heartRenderer.sprite = fullHeart;
                break;
            case 3:
                heartRenderer.sprite = threeQuarterHeart;
                break;
            case 2:
                heartRenderer.sprite = halfHeart;
                break;
            case 1:
                heartRenderer.sprite = quarterHeart;
                break;
            default:
                heartRenderer.sprite = quarterHeart;
                break;

        }
    }
}
