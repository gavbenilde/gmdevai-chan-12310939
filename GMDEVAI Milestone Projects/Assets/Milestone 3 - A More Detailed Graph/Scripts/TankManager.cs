using UnityEngine;

public class TankManager : MonoBehaviour
{
    public FollowPath currentTank = null;
    
    public void SetCurrentTank(FollowPath tank)
    {
        // turn OFF previous tank
        if (currentTank != null)
            currentTank.isActive = false;

        // set new tank
        currentTank = tank;

        // turn ON new tank
        if (currentTank != null)
            currentTank.isActive = true;
    }

    public void GoTo(int index)
    {
        Debug.Log("Moving: " + currentTank.name);
        
        if (currentTank != null)
            currentTank.GoToWaypoint(index);
    }
}