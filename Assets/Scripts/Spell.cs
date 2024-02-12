using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    SpellSlot boil, crush, dry;
    bool canCast = false;

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
            || crush.ingredient.crushEffect == SpellEffect.None
            || dry.ingredient.dryEffect == SpellEffect.None)
        {
            canCast = false;
            Debug.Log("No spell combination!");
        }
        else if (GameManager.INSTANCE.inventory.items[boil.ingredient] <= 0
            || GameManager.INSTANCE.inventory.items[crush.ingredient] <= 0
            || GameManager.INSTANCE.inventory.items[dry.ingredient] <= 0)
        {
            canCast = false;
            Debug.Log("Not enough ingredients!");
        }
        else
        {
            canCast = true;
        }

        if(canCast)
        {
            CastSpell();
        }

        return canCast;
    }

    private void CastSpell()
    {
        string msg = $"{boil.ingredient.boilEffect} + {crush.ingredient.crushEffect} + {dry.ingredient.dryEffect}";
        Debug.Log(msg);
    }
}
