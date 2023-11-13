using System;
using UltimateXR.Avatar;
using UltimateXR.Core;
using UltimateXR.Devices;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [Header("Input parameters")]
    [SerializeField] public UxrHandSide HandSide;
    [SerializeField] public UxrInputButtons Button;

    [SerializeField]
    private GameObject targetObject;

    private bool wasPressed; 

    private void Update()
    {        bool currentPressState = UxrAvatar.LocalAvatarInput.GetButtonsPressDown(HandSide, Button);

        if (currentPressState)
        {
            targetObject.SetActive(!targetObject.activeSelf);
            currentPressState = !currentPressState;
        }
    }
}


/*
 
 @Ixyz, as a continuation on your ⁠general message. 😄

If you're curious as to how to implement the events (which is also my personal favorite and a far more efficient method as opposed to checking every single frame.
All you need to do is subscribe to the event in your Start() and unsubscribe OnDestroy().

Here is an example of how to do that with the code you had written already and a bit extra with explanations etc.

using UltimateXR.Devices;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [Header("Input parameters")]
    [SerializeField] public UxrHandSide HandSide;
    [SerializeField] public UxrInputButtons Button;

        //When the GameObject this script has attached to is initialized, this will fire.
        private void Start()
        {
            //We're subscribing at the start when this script is initialized.
            UxrControllerInput.GlobalButtonStateChanged += Input_ButtonStateChanged;
        }

        //When the GameObject this script has attached to is destroyed, this will fire.
        private void OnDestroy()
        {
            //We're unsubscribing from the event preventing it from being called after the game object is destroyed.
            //This prevents memory leaks etc
            UxrControllerInput.GlobalButtonStateChanged -= Input_ButtonStateChanged;
        }

        private void Input_ButtonStateChanged(object sender, UxrInputButtonEventArgs e)
        {
            //We can do whatever we want here when any type of button is pressed.
            Debug.Log($"Pressed {e.HandSide}, {e.Button}, {e.ButtonEventType}");

            //If you want to listen to a specific button being pressed, you may use any of the enumerators of UxrInputButtons.
            //For this example we're using Trigger.
            //Be aware, this event is being fired every frame update, so if you're spawning bullets this way with 90FPS(90Hz), 
            //you're shooting 90 bullets a second haha.
            if ((e.Button & UxrInputButtons.Trigger) != 0)
            {
                //Do something when button is pressed.
                Debug.Log("Trigger pressed!");
            }
        }
}
The Input_ButtonStateChanged is the method we're calling whenever the event is fired.

You could interpret it as 
if(UxrControllerInput.GlobalButtonStateChanged){
  Input_ButtonStateChanged();
}

Don't know if that made it easier to understand what's happening here. haha

You can name this anything you want. 

 */
