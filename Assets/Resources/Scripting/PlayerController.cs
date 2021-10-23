using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Sprite spriteRenderer;
    public Sprite shield;
    public Sprite deflector;
    public bool isShielding;
    // Start is called before the first frame update
    void Start()
    {
        isShielding = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        checkForShieldingAndUpdateSprite();
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePosition - transform.position);
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
}
