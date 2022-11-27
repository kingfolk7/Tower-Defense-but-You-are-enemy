using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textscore;
    [SerializeField] private TextMeshProUGUI textRound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textscore.text = $"Score = {ScoreManager.instance._score}" + $"/{ScoreManager.instance.scoreVictory}";
        textRound.text = $"Round = {GameManager.rounds}" + "/5";
    }
    
}
