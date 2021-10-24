using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObjectiveHandler : MonoBehaviour
{
    public GameObject orb1, orb2, orb3, orb4, orb5, orb6, orb7, orb8, orb9;
    public AudioSource battleSong, endSong;
    public int nextScene;
    public string[] shitTalk;
    public Text bossText;

    // Start is called before the first frame update
    void Start()
    {
        battleSong.enabled = true;
        InvokeRepeating("updateBattleText", 1f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        checkIfObjectiveAccomplished();
    }

    private void updateBattleText()
    {
        var rand = Random.Range(0, (shitTalk.Length-1));
        bossText.text = shitTalk[rand];
    }

    private void checkIfObjectiveAccomplished()
    {
        if(orb1 == null &&
            orb2 == null &&
            orb3 == null &&
            orb4 == null &&
            orb5 == null &&
            orb6 == null &&
            orb7 == null &&
            orb8 == null &&
            orb9 == null)
        {
            GameObject.Find("Handlers").GetComponent<GlobalGameHandler>().endBattle();
            battleSong.enabled = false;
            SceneManager.LoadScene(nextScene);
            GameObject.Find("Handlers").GetComponent<GlobalGameHandler>().health = 4;
            //Todo say text
            //Todo play song
        }
    }
}
