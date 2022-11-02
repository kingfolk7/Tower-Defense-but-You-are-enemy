using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public CharacterMove[] characterMoves;
    // Start is called before the first frame update
    void Start()
    {
       characterMoves = FindObjectsOfType<CharacterMove>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
