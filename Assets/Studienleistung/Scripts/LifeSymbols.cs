using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LifeSymbols : MonoBehaviour {

    public int position;
    public PlayerManager m_player;

	
	// draws the correct amount of health images during the game
	void Update () {
	    if (GetComponent<Image>().enabled && m_player.HealthPoint < position )
        {
            GetComponent<Image>().enabled = false;
        }
	}
}
