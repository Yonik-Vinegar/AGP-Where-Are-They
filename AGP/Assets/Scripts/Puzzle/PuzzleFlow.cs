using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleFlow : MonoBehaviour
{
    //How it works: colliders on both ends of juntions and "pipes". Empties on parts, corners and ends,  invisible sphere moves to these empties and only can move to next ones when colliders are touching. 
    // Start is called before the first frame update
    public GameObject[] PositionList;
    public GameObject[] PipeList;
    public GameObject[] JunctionList;
    int currentPositionIndex;
    private bool MoveToNextPosition = true;
    private bool CurrentEnergyPos;
    private float speed = 0.5f;

    private void OnTriggerEnter(Collider other)
    {
        
    }
    // Update is called once per frame
    void Update()
    {

       if (MoveToNextPosition = true)
       {
            transform.position = Vector3.MoveTowards(transform.position, PositionList[currentPositionIndex].transform.position, speed * Time.deltaTime);
            
            if (transform.position == PositionList[currentPositionIndex].transform.position)
            {
                currentPositionIndex++;
            }
       }




    }


}
