/*
    File made by TGL(The Game Learner)
    Learning purpose
    v 1.0
*/

using System.Collections;
using System.Collections.Generic;
using TGLUtility.ObserverPattern;
using UnityEngine;

public class GameControllerObsrPtrn : MonoBehaviour
{
    //Unity Hierarchy References
    public Transform ballObj;
    public List<Transform> floorGems;
    public Transform floorControllerObj; // has FloorData and MaterialColorChanger Attached to it

    // Observer Pattern
    private IObservedObj _subjectInstance; 
    private List<ObserverObj> _fgObservers;
    private Dictionary<ObserverObj, Transform> _observerControllers;

	private void Awake()
	{
        _subjectInstance = ballObj.gameObject.AddComponent<ObservedObj>();
        if(_subjectInstance == null)
		{
            Debug.LogError("No Subjectable instance found in " + ballObj);
		}

        if (_fgObservers == null)
		{
            _fgObservers = new List<ObserverObj>();
		}

        //Validate List, add Floor Gems Observers for each
        foreach (Transform floorGem in floorGems)
		{
            if(floorGem.GetComponent<FloorGems>() == null)
			{
                floorGems.Remove(floorGem);
            }
            else
			{
                ObserverObj fgObserver = new ObserverObj(_subjectInstance); // adding a new Observer for the Subject
                fgObserver.SetConnectedGameObject(floorGem);
            }
		}

        //Add floor Controller observer to floor data object
        FloorObserverController floorDataController = new FloorObserverController(_subjectInstance);
        floorDataController.SetConnectedGameObject(floorControllerObj);

    }
}