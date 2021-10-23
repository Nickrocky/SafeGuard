using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
    public GameObject firstSpawnAble, secondSpawnable;

    [SerializeField] private Difficulty orbDifficulty;

    public GameObject heartLocation;
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.forward, heartLocation.transform.position - transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (willIShoot(orbDifficulty))
        {
            if (hasSecondAbility())
            {
                //If it has one then check to see if primary or secondary fire
                if (willUseSecondary())
                {
                    Instantiate(secondSpawnable);
                }
                else
                {
                    Instantiate(firstSpawnAble);
                }
            }
            else
            {
                //Just fire a normal damn projectile
                Instantiate(firstSpawnAble);
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