using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCooldown : MonoBehaviour
{
    [SerializeField] float coolDownDuration;
    [SerializeField] Image uiFill;
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
        float maxCool = coolDownDuration;
        while (coolDownDuration >= 0)
        {
            mybutton.interactable = false;
            uiFill.fillAmount = Mathf.InverseLerp(maxCool, 0, coolDownDuration);
            coolDownDuration-= 1 * Time.deltaTime;
            yield return null; 
        }
 
        mybutton.interactable = true;
        coolDownDuration = maxCool;

    }
    // Update is called once per frame
    
}
