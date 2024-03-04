using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable] 
public class TurretBlueprint
{
    public GameObject prefab; 
    public int cost; 
}

public class TurretPlacer : MonoBehaviour
{
    public TurretBlueprint[] turrets; 
    private TurretBlueprint selectedTurret;
    private GameObject turretPreviewInstance;

    void Update()
    {
        if (selectedTurret != null)
        {
            MoveTurretPreview();

            if (Input.GetMouseButtonDown(0))
            {
                TryPlaceTurret();
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                CancelTurretPlacement();
            }
        }
    }

    public void SelectTurretToPlace(int index)
    {
        if (turretPreviewInstance != null)
        {
            Destroy(turretPreviewInstance); 
        }
        selectedTurret = turrets[index]; 
        turretPreviewInstance = Instantiate(selectedTurret.prefab); 
        
    }

    void MoveTurretPreview()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (turretPreviewInstance != null)
            {
                turretPreviewInstance.transform.position = hit.point;
            }
        }
    }

    void TryPlaceTurret()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            PlacementArea placementArea = hit.collider.GetComponent<PlacementArea>();
            if (placementArea != null && placementArea.CanPlace())
            {
                if (GameManager.instance.PlayerResources >= selectedTurret.cost)
                {
                    GameObject turretObj = Instantiate(selectedTurret.prefab, hit.point, Quaternion.identity);
                    turretObj.GetComponent<Turret>().SetPlaced(); 
                    placementArea.PlaceTurret();
                    GameManager.instance.UpdateResources(-selectedTurret.cost); 
                    Destroy(turretPreviewInstance); 

                    selectedTurret = null;
                }
                else
                {
                    GameManager.instance.ShowWarning("Yetersiz kaynak!"); 
                }
            }
        }
    }
    void CancelTurretPlacement()
    {
 
        Destroy(turretPreviewInstance);
        turretPreviewInstance = null;
        selectedTurret = null; 
    }

}


