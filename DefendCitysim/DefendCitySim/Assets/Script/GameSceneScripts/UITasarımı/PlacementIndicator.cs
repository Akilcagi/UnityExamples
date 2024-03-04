using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlacementIndicator : MonoBehaviour
{
    public GameObject placementIndicatorPrefab; 
    public float displayDuration = 5.0f; 

  
    public Text warningText; 

    [System.Obsolete]
    void Start()
    {
        warningText.gameObject.SetActive(false); 
        foreach (var placementPoint in FindObjectsOfType<PlacementArea>())
        {
            Vector3 positionWithY = new Vector3(placementPoint.transform.position.x, 487.4f, placementPoint.transform.position.z);
            Quaternion rotationY = Quaternion.Euler(0, 90, 0);
            GameObject indicator = Instantiate(placementIndicatorPrefab, positionWithY, rotationY);
            StartCoroutine(AnimateIndicatorWithText(indicator, warningText));
        }
    }

    IEnumerator AnimateIndicatorWithText(GameObject indicator, Text warningText)
    {
        float animationDuration = 1.0f; 
        float heightDifference = 0.5f; 
        float displayDuration = 5.0f; 

        Vector3 startPosition = indicator.transform.position;
        Vector3 endPosition = startPosition + new Vector3(0, heightDifference, 0);

        warningText.text = "Turretlerinizi se�ili b�lgelere yerle�tirin";
        warningText.gameObject.SetActive(true);

        float startTime = Time.time; 

        while (Time.time - startTime < displayDuration)
        {
           
            float time = 0;
            while (time < animationDuration && Time.time - startTime < displayDuration)
            {
                indicator.transform.position = Vector3.Lerp(startPosition, endPosition, time / animationDuration);
                time += Time.deltaTime;
                yield return null;
            }

           
            time = 0;
            while (time < animationDuration && Time.time - startTime < displayDuration)
            {
                indicator.transform.position = Vector3.Lerp(endPosition, startPosition, time / animationDuration);
                time += Time.deltaTime;
                yield return null;
            }
        }

        warningText.gameObject.SetActive(false); 
        Destroy(indicator); 
    }


}
