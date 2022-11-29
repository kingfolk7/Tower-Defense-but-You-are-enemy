using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private List<CharacterMove> characterMoves = new List<CharacterMove>();
    public static int rounds = 1;
    static int GotoSceneNum = 3;
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
        if(rounds >= 6)
        {
            if(GotoSceneNum < 5 && ScoreManager.instance._score > ScoreManager.instance.scoreVictory)
            {
                GotoSceneNum++;
                GoToNextScene();
            }
            else
            {
                GameEnd();
                 
            }

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
            SceneManager.LoadScene(GotoSceneNum, LoadSceneMode.Single);
            rounds++;
        }
       
    }

    void GameEnd()
    {
        rounds = 1;
        if (ScoreManager.instance._score > ScoreManager.instance.scoreVictory)
        {
            SceneManager.LoadScene("Win");
            GotoSceneNum = 3;
        }
        else
        {
            SceneManager.LoadScene("Lose");
            GotoSceneNum = 3;
        }
        ScoreManager.instance._score = 0;


    }
    void GoToNextScene()
    {
        rounds = 1;
        SceneManager.LoadScene(GotoSceneNum, LoadSceneMode.Single);
        ScoreManager.instance._score = 0;

    }
}
