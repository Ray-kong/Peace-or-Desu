using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateLayering : MonoBehaviour
{

    public GameObject WalkNorth;
    public GameObject WalkSouth;
    public GameObject WalkEast;
    public GameObject WalkWest;
    public GameObject Damage;
    public GameObject Death;



    // Start is called before the first frame update
    void Start()
    {

       
        // WalkSouth = active, NPC is looking towards the player
        WalkNorth.SetActive(false);
        WalkSouth.SetActive(true);
        WalkEast.SetActive(false);
        WalkWest.SetActive(false);
        Damage.SetActive(false);
        Death.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
