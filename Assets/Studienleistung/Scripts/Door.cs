using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

    public bool isOpen = false;
    private bool isOpening = false;

    public void doorAnimation()
    {
        isOpening = true;
        GetComponent<AudioSource>().Play();
    }

    //Opens the correct door when doorAnimation is being called from onClick() Button
    void Update()
    {
        if (isOpening && DoorTrigger.triggerDoor.transform.position.y >= -1.5f)
        {
           
            DoorTrigger.triggerDoor.transform.Translate(0, -0.02f, 0);
            
        }
        else
        {
            
            isOpening = false;
            isOpen = true;          
          
        }
    }

}
