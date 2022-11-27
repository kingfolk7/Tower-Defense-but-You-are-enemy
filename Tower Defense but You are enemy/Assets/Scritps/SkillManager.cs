using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Skill
{
    private MonoBehaviour _coroutineRunner;

    public Skill(MonoBehaviour coroutineRunner)
    {
        _coroutineRunner = coroutineRunner;
    }

    protected float delay; 
    public void UseSkill(CharacterMove cha)
    {
        ApplyBuff(cha);
        _coroutineRunner.StartCoroutine(DelayThenRemoveBuff(cha));
    }

    public abstract void ApplyBuff(CharacterMove cha);

    public abstract void RemoveBuff(CharacterMove cha);

    IEnumerator DelayThenRemoveBuff(CharacterMove cha)
    {
        yield return new WaitForSeconds(delay);
        RemoveBuff(cha);
    }
}

class IncreaseSpeed : Skill
{
    public IncreaseSpeed(MonoBehaviour coroutineRunner) : base(coroutineRunner)
    {
    }

    public override void ApplyBuff(CharacterMove cha)
    {
        cha.speedDefault = cha.speedDefault * 2;
        delay = 3.0f;
        Debug.Log("Incrsase");
    }
    public override void RemoveBuff(CharacterMove cha)
    {
        cha.speedDefault = 1.0f;
    }

}

class IncreaseHp : Skill
{
    public IncreaseHp(MonoBehaviour coroutineRunner) : base(coroutineRunner)
    {
    }

    public override void ApplyBuff(CharacterMove cha)
    {
        if(cha.health < 100)
        {
            cha.health += 30;
            cha.Healthbar.SetHealth(cha.health, cha.maxHP);
            if (cha.health > 100)
            {
                cha.health = 100;
            }
        }
       

    }

    public override void RemoveBuff(CharacterMove cha)
    {
        return;

    }
}

class ImmuneTank : Skill
{
    public ImmuneTank(MonoBehaviour coroutineRunner) : base(coroutineRunner)
    {
    }

    public override void ApplyBuff(CharacterMove cha)
    {
        
        cha.setImmune(true);
        delay = 1.0f;

    }

    public override void RemoveBuff(CharacterMove cha)
    {
        cha.setImmune(false);
    }
}

class FreezeMAXHP : Skill
{
    public FreezeMAXHP(MonoBehaviour coroutineRunner) : base(coroutineRunner)
    {
    }

    public override void ApplyBuff(CharacterMove cha)
    {

        if (cha.health < 100)
        {
            cha.health += 50;
            cha.Healthbar.SetHealth(cha.health, cha.maxHP);
            if (cha.health > 100)
            {
                cha.health = 100;
            }
        }
        cha.speedDefault = 0.0f;
        delay = 3.0f;


    }

    public override void RemoveBuff(CharacterMove cha)
    {
        cha.speedDefault = 1.0f;
    }
}
public class SkillManager : MonoBehaviour
{
    [SerializeField] private EnemyManager _enemyManager;

    public void ApplySpeedtoAll()
    {
        foreach(CharacterMove characterMove in FindObjectOfType<EnemyManager>().characterMoves)
        {
            characterMove.ApplySkill(new IncreaseSpeed(this));
            
        }
        
    }

    public void ApplyHPtoAll()
    {
        foreach (CharacterMove characterMove in FindObjectOfType<EnemyManager>().characterMoves)
        {
            characterMove.ApplySkill(new IncreaseHp(this));

        }

    }

    public void ApplyImmunetoAll()
    {
        foreach (CharacterMove characterMove in FindObjectOfType<EnemyManager>().characterMoves)
        {
            characterMove.ApplySkill(new FreezeMAXHP(this));

        }

    }

    public void ApplyImmunetoTank()
    {
        /*
        foreach (CharacterMove characterMove in FindObjectOfType<EnemyManager>().characterMoves)
        {
            characterMove.ApplySkill(new Immune(this));

        }
        */

        _enemyManager.characterMoves[0].ApplySkill(new ImmuneTank(this));
    }
}
