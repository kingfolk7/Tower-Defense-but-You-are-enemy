using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private List<CharacterMove> characterMoves = new List<CharacterMove>();
    public static int rounds = 0;
    // Start is called before the first frame update
    // Update is called once per frame

    private void Start()
    {
    }
    void Update()
    {
        //if (characterMoves[0].isDie(true))
        //{
        //    Debug.Log("Die true");
        //    SceneManager.LoadScene("SampleScene");
        //    characterMoves[0].isDie(false);
        //}
        if(rounds > 5)
        {
            GameEnd();
        }
    }

    public void RegisterCharacter(CharacterMove character)
    {
        characterMoves.Add(character);
    }

    public void NotifyDeath(CharacterMove character)
    {
        characterMoves.Remove(character);

        if (characterMoves.Count == 0)
        {
            SceneManager.LoadScene("SampleScene");
            rounds++;
        }
       
    }

    void GameEnd()
    {
        
        SceneManager.LoadScene("Main_Menu");
        rounds = 0;
        ScoreManager.instance._score = 0;
        
    }
}
