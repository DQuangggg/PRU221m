using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayPanel : MonoBehaviour
{
    public CharacterController characterController;
    public GuidePanel guidePanel;

    void Start()
    {
        characterController.AddObserver(guidePanel);
    }
}
 