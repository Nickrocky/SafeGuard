using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
    public GameObject firstSpawnAble, secondSpawnable;

    [SerializeField] private Difficulty orbDifficulty;

    public GameObject heartLocation;
    private void Awake()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.forward, heartLocation.transform.position - transform.position);
        //transform.rotation.SetLookRotation(heartLocation.transform.parent.position);
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("shoot", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void shoot()
    {
        if (willIShoot(orbDifficulty))
        {
            if (hasSecondAbility())
            {
                //If it has one then check to see if primary or secondary fire
                if (willUseSecondary())
                {
                    var newBullet = Instantiate(secondSpawnable);
                    newBullet.transform.rotation = gameObject.transform.rotation;
                    newBullet.transform.position = gameObject.transform.position;
                }
                else
                {
                    var newBullet = Instantiate(firstSpawnAble);
                    newBullet.transform.rotation = gameObject.transform.rotation;
                    newBullet.transform.position = gameObject.transform.position;
                }
            }
            else
            {
                //Just fire a normal damn projectile
                var newBullet = Instantiate(firstSpawnAble);
                newBullet.transform.rotation = gameObject.transform.rotation;
                newBullet.transform.position = gameObject.transform.position;
            }
        }
    }
    private bool willUseSecondary()
    {
        var value = Random.Range(1, 100);
        if (value <= 25) return true;
        return false;
    }

    private bool hasSecondAbility()
    {
        switch (orbDifficulty)
        {
            case Difficulty.CHILDISH:
            case Difficulty.EASY:
            case Difficulty.MODERATE:
            default:
                return false;
            case Difficulty.HARD:
            case Difficulty.OVERKILL:
            case Difficulty.EXTREME:
                return true;
        }
    }

    private bool willIShoot(Difficulty difficulty)
    {
        var value = Random.Range(1, 100);
        if (value >= ((int)difficulty)) return true;
        return false;
    }

}

public enum Difficulty : int
{
    CHILDISH = 90,
    EASY = 80,
    MODERATE = 60,
    HARD = 40,
    OVERKILL = 20,
    EXTREME = 10,
}