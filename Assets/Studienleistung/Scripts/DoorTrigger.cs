using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DoorTrigger : MonoBehaviour {

   
    public GameObject DoorOpenPanel;
    static public Door triggerDoor;
   

   //Opens the Door Open Panel when TriggerZone is entered and closes it when TriggerZone is left
    void OnTriggerEnter(Collider collider)
    {
      
        DoorOpenPanel.SetActive(true);
        triggerDoor = transform.parent.parent.GetComponentInChildren<Door>();
      
    }

    void OnTriggerExit(Collider collider)
    {
        DoorOpenPanel.SetActive(false);
    }

   


}
