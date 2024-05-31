using UnityEngine;
using RootMotion.FinalIK;

public class FPSAnimation : MonoBehaviour
{
    private InteractionSystem _interactionSystem;
    [SerializeField] private InteractionObject aimLeftHandIB;
    [SerializeField] private InteractionObject aimRightHandIB;

    private void Start()
    {
        _interactionSystem = GetComponent<InteractionSystem>();
        Invoke("AimHandInteraction", 2);
    }

    private void AimHandInteraction()
    {
        _interactionSystem.StartInteraction(FullBodyBipedEffector.LeftHand, aimLeftHandIB, false);
        _interactionSystem.StartInteraction(FullBodyBipedEffector.RightHand, aimRightHandIB, false);
    }
}
