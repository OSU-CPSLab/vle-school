using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR.InteractionSystem;
using Valve.VR;


public class ButtonInteractable : MonoBehaviour
{
    private Interactable interactable;
    private Hand interHand;

    public SteamVR_Action_Boolean buttonPress;
    public Animator buttonAnim;

    [Space] [Space] [Space]
    public UnityEvent pressedEvent;
    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if(interactable.isHovering) {
            if(interHand == null) {
                interHand = interactable.hoveringHand;
                buttonPress.AddOnStateDownListener(ButtonPressed, interHand.handType);
            }    
        }
        else {

            if(interHand != null) {
                buttonPress.RemoveAllListeners(interHand.handType);
                interHand = null;
            }
        }
    }

    public void ButtonPressed(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource) {
        StartCoroutine(activateButton());
        buttonPress.RemoveAllListeners(interHand.handType);
        interHand = null;
        pressedEvent.Invoke();

    }

    private IEnumerator activateButton() {

        if(buttonAnim != null)
        {
            buttonAnim.SetBool("buttonPressed", true);

            yield return new WaitForSeconds(0.01f);

            buttonAnim.SetBool("buttonPressed", false);
        }
    }

}
