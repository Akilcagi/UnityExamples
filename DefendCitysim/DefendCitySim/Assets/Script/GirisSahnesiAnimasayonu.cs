using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GirisSahnesiAnimasayonu : MonoBehaviour
{
    public Slider y�kleme�ubu�u;
    public float y�klemeS�resi = 5f; 
    void Start()
    {
        if (y�kleme�ubu�u != null)
        {
            StartCoroutine(Y�klemeSim�lasyonu());
        }
    }

    IEnumerator Y�klemeSim�lasyonu()
    {
        float ge�enZaman = 0f;
        while (ge�enZaman < y�klemeS�resi)
        {
            ge�enZaman += Time.deltaTime;
            y�kleme�ubu�u.value = Mathf.Clamp01(ge�enZaman / y�klemeS�resi);
            yield return null;
        }

        SceneManager.LoadScene("AnaMenu"); 
    }
}
