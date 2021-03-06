﻿using UnityEngine;
using UnityEngine.UI;

namespace RockPaperSpell.View
{
    public class Spell : IndexBehaviour
    {
        [SerializeField] private Text spellText = null;

        public Structs.Spell GetStruct()
        {
            return new Structs.Spell
            {
                name = spellText.text
            };
        }

        public void SetSpell(Structs.Spell spell)
        {
            spellText.text = spell.name;
        }

        public void CopySpell(Spell spell)
        {
            spellText.text = spell.spellText.text;
        }
    }
}