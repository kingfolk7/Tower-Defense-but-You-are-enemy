using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private List<CharacterMove> characterMoves = new List<CharacterMove>();
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
        }
    }
}
