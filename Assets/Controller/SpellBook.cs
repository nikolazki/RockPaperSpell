﻿namespace RockPaperSpell.Controller
{
    public class SpellBook : Controller<Interfaces.SpellBook>
    {
        public void SetSpellBook(Model.SpellBook spellBook)
        {
            spellBook.AddListenerNewSpell(view.AddSpell);
        }
    }
}