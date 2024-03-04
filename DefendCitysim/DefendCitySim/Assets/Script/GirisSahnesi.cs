using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GirisSahnesi : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(AnaMenuyeGecis());
    }

    IEnumerator AnaMenuyeGecis()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("AnaMenu");
    }
}
