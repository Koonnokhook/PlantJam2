using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//could 
public class PlantSkill : MonoBehaviour
{
    public int maxDefense = 100;
    public int currentDefense;


    public void ApplyPoisonEffect(int duration, int poisonAmount)
    {
        StartCoroutine(PoisonEffectCoroutine(duration, poisonAmount));
    }

    private IEnumerator PoisonEffectCoroutine(int duration, int poisonAmount)
    {
        for (int i = 0; i < duration; i++)
        {

            ReduceDefense(poisonAmount);

            yield return new WaitForSeconds(1.0f); 
        }

    }

    private void ReduceDefense(int amount)
    {
        currentDefense -= amount;

        if (currentDefense < 0)
        {
            currentDefense = 0;
        }
    }
}
