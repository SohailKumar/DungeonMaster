using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(fileName = "New Trap", menuName = "Trap/Create New Trap")]

public class Trap : ScriptableObject
{
    public string trapname;
    public int cost;
    public Sprite image;
    public int damage;
    public float atkSpeed;
    public UnityEditor.Animations.AnimatorController animator;
    public bool knockback;
}
