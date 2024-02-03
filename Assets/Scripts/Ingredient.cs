using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Ingredient", menuName = "ScriptableObjects/Ingredient", order = 1)]
public class Ingredient : ScriptableObject
{
    public string ingredientName;
    public Sprite ingredientImage;
    public Sprite notAvailableImage;
    public SpellEffect boilEffect;
    public SpellEffect crushEffect;
    public SpellEffect dryEffect;
}

public enum SpellEffect
{
    // Default
    None,

    // Attack Types
    AOE,
    Beam,
    Projectile,
    Burst,
    Self,
    AOESelf,

    // Elements
    Fire,
    Ice,
    Water,
    Wind,
    Earth,
    Lightning,
    Laser,
    Plasma,

    // Effects On Target (self or other)
    Paralysis,
    Sleep,
    Push,
    Jump,
    Speak,
    Panic,
    Freeze,
    Burn,
    Drench,
    Electrocute,
    Damage,

    // Effects On Collision
    Explode,
    GasCloud,
    Linger,
    Puddle,

    // Spell Modifiers
    ExtraDamage,
    ExtraRange,
    ExtraEffectTime,
    ExtraSpeed,
}