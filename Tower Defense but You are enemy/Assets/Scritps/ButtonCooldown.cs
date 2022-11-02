using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCooldown : MonoBehaviour
{
    [SerializeField] float coolDownDuration;
    [SerializeField] Button mybutton;
    // Start is called before the first frame update
    void Awake()
    {
        mybutton = GetComponent<Button>();

        if(mybutton != null)
        {
            mybutton.onClick.AddListener(OnButtonClick);
        }
    }

    void OnButtonClick()
    {
        StartCoroutine(Cooldown());
    }

    IEnumerator Cooldown()
    {
        mybutton.interactable = false;
        yield return new WaitForSeconds(coolDownDuration);
        mybutton.interactable = true;

    }
    // Update is called once per frame
    
}
