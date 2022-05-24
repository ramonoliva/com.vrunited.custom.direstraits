using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using QuickVR;

public class TestStartConcert : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (InputManagerVR.GetKeyDown(InputManagerVR.ButtonCodes.LeftPrimaryPress))
        {
            ConcertStarter.START_CONCERT = true;
        }
    }
}
