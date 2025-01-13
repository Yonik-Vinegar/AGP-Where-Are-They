using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PuzzleFlow : MonoBehaviour
{
    //How it works: colliders on both ends of juntions and "pipes". Empties on parts, corners and ends,  invisible sphere moves to these empties and only can move to next ones when colliders are touching. 
    // Start is called before the first frame update
    public GameObject[] PositionList;
    public GameObject[] Junctions;
    int currentPositionIndex;
    private bool MoveToNextPosition = true;
    private bool CurrentEnergyPos;
    private float speed = 0.5f;
    public GameObject junctionManager;
    Junction[] junctionAlignment;
    private bool EnergyCanMove;
    private bool EnergyNotAtCheck = true;
    private bool ReachedCheck;
    private bool finalCheck;

    [Header("Doing boolean checks yippee")]
    public int JunctionCount;



    private void Awake()
    {
        //junctionAlignment = junctionsManager.GetComponentInChildren<Junction>();

    }

    // Update is called once per frame
    void Update()
    {
        if (MoveToNextPosition == true) //junctionAlignment.EnergyCanMove
        {
            if (finalCheck == true)
            {
                Debug.Log("Is this being called?");
                transform.position = Vector3.MoveTowards(transform.position, PositionList[currentPositionIndex].transform.position, speed * Time.deltaTime);
                if (transform.position == PositionList[currentPositionIndex].transform.position)
                {
                    currentPositionIndex++;
                    Debug.Log(currentPositionIndex);
                }
            }
            if (currentPositionIndex >= PositionList.Length)
            {
                MoveToNextPosition = false;
            }
        }
        if (ReachedCheck == true)
        {
            EnergyNotAtCheck = false;
        }
        else
        {
            EnergyNotAtCheck = true;
        }


    }
    //checks to see if the junction is aligned so the energy can continue moving. Issue is, if there is more than one junction, it will take the value from the first one
    //thus making it so you can complete the puzzle by doing only one junction. Not the two of them.
    //Also this might be me being a dumbass, but when the energy gets to the junction and it's not aligned then it cannot reenter to attempt to retrigger.
    private void OnTriggerEnter(Collider Other)
    {
        if (Other.CompareTag("PuzzleCheckPos"))
        {
            ReachedCheck = true;
            Debug.Log("Is triggering the check");
            if (Other.gameObject.GetComponent<PuzzleCheck>().EnergyCanProceed == true)
            {
                Debug.Log("WAAGH");
                EnergyCanMove = true;
            }
        }
        else
        {
            ReachedCheck = false;
        }
    }

    private void CheckingForAlignment()
    {
        //bool[] JunctionsAlignCheck = new JunctionAlighCheck[JunctionCount];
        //junctionAlignment.junctionAlignment.Junction.JunctionAligned(out JunctionsAlignCheck[JunctionCount++])
        //junctionALignment.junctionAlignment.junction.JunctionAligned(out JunctionAlignCheck[)
        // finalCheck = true;
        // foreach (bool JunctionCompleted in JunctionsAlignCheck)
        // {
        //     if (JunctionCompleted == false)
        //     {
        //         finalCheck = false;
        //     }
        // }

    }

}
