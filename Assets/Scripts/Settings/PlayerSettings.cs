using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSettings", menuName = "Shooter/PlayerSettings")]
public class PlayerSettings : ScriptableObject {
    public float MovementSpeed;
    public float JumpHeight;
    [Range(0, 1)]
    [Tooltip("Speed adjustment in crouch mode. As (speed * crouchModifier")]
    public float CrouchingModifier;
}
