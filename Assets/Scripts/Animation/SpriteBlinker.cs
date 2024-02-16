using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteBlinker : MonoBehaviour
{
    [SerializeField] SpriteRenderer rend;
    [SerializeField] float timeBetweenChange = 1;
    [SerializeField] string blinkFieldName = "_FlashAmount";
    [SerializeField] string colorFieldName = "_FlashColor";

    public void PlayFlash(float time)
    {
        PlayFlash(time, 1);
    }

    public void PlayFlash(float time, float amount)
    {
        StartCoroutine(FlashRoutine(time, amount));
    }

    IEnumerator FlashRoutine(float time, float amount)
    {
        float currentTime = 0;
        while(currentTime <= time)
        {
            SetFlashAmount(amount);
            yield return new WaitForSeconds(timeBetweenChange);
            SetFlashAmount(0);
            currentTime += timeBetweenChange;
            yield return new WaitForSeconds(timeBetweenChange);
            currentTime += timeBetweenChange;
        }        
    }

    public void SetFlashAmount(float value)
    {
        rend.material.SetFloat(blinkFieldName, value);
    }

    public void SetFlashColor(Color value)
    {
        rend.material.SetColor(colorFieldName, value);
    }
}
