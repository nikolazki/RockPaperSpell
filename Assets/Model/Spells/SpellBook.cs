﻿using System.Collections.Generic;

namespace RockPaperSpell.Model
{
    public class SpellBook
    {
        private List<Spell> spells;
        private int offensive, defensive, gold, size;

        public SpellBook(int wizards)
        {
            spells = new List<Spell>();
            if (wizards > 5)
                size = 5;
            else
                size = wizards;
        }

        public SpellType ValidSpell()
        {
            return SpellTypeUtility.CreateSpellType(offensive < 2, defensive < 2, gold < 2);
        }

        public Spell AddSpell(Spell spell)
        {
            Spell res = null;
            AddSpellToList(spell);
            if (spells.Count > size)
            {
                res = RemoveSpellFromList(0);
            }
            return res;
        }

        public int SpellsBefore(Spell spell)
        {
            int index = spells.IndexOf(spell);
            int res;
            if (index < 0)
            {
                res = 0;
            }
            else
            {
                res = size - index - 1;
            }
            return res;
        }

        private void AddSpellToList(Spell spell)
        {
            spells.Add(spell);
            AddRemoveType(spell, true);
        }

        private Spell RemoveSpellFromList(int index)
        {
            Spell spell = spells[index];
            spells.Remove(spell);
            AddRemoveType(spell, false);
            return spell;
        }

        private void AddRemoveType(Spell spell, bool add)
        {
            switch (spell.Type)
            {
                case SpellType.Offensive:
                    offensive += add ? 1 : -1;
                    break;
                case SpellType.Defensive:
                    defensive += add ? 1 : -1;
                    break;
                case SpellType.Gold:
                    gold += add ? 1 : -1;
                    break;
            }
        }
    }
}