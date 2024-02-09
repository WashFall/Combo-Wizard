using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    SpellSlot boil, crush, dry;
    bool canCast = false;
    bool spellSubmitted = false;

    private void Start()
    {
        boil = transform.GetChild(0).GetComponent<SpellSlot>();
        crush = transform.GetChild(1).GetComponent<SpellSlot>();
        dry = transform.GetChild(2).GetComponent<SpellSlot>();
        GameManager.INSTANCE.onCastSpell += TrySpell;
    }

    public bool TrySpell()
    {
        if(boil.ingredient.boilEffect == SpellEffect.None 
            ||
            crush.ingredient.crushEffect == SpellEffect.None
            ||
            dry.ingredient.dryEffect == SpellEffect.None)
        {
            canCast = false;
        }
        else
        {
            canCast = true;
        }

        if(canCast)
        {
            CastSpell();
        }

        return true;
    }

    private void CastSpell()
    {
        spellSubmitted = true;
        string msg = $"{boil.ingredient.boilEffect} + {crush.ingredient.crushEffect} + {dry.ingredient.dryEffect}";
        Debug.Log(msg);
    }
}
