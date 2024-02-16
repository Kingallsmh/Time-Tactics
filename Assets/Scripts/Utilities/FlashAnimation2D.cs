using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashAnimation2D : MonoBehaviour
{
    [SerializeField] SpriteRenderer[] renders;
    [SerializeField] Color flashColor;
    [SerializeField] float flashtime;

    private void Start()
    {
        for (int i = 0; i < renders.Length; i++)
        {
            renders[i].material.EnableKeyword("_FlashAmount");
        }
    }

    public void Flash()
    {
        StartCoroutine(FlashRoutine(flashtime));
    }

    IEnumerator FlashRoutine(float time)
    {
        SetFlashAmount(1);
        yield return new WaitForSeconds(time);
        SetFlashAmount(0);
    }

    public void SetRenderColor(Color color)
    {
        for (int i = 0; i < renders.Length; i++)
        {
            renders[i].material.SetColor("_FlashColor", color);
        }
    }

    void SetFlashAmount(float value)
    {
        for (int i = 0; i < renders.Length; i++)
        {
            renders[i].material.SetFloat("_FlashAmount", value);
        }
    }
}
