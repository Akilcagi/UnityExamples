using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementArea : MonoBehaviour
{
    public bool isOccupied = false;

   
    public bool CanPlace()
    {
        return !isOccupied;
    }

    
    public void PlaceTurret()
    {
        isOccupied = true;
       
    }
}
