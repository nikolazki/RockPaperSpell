﻿using Mirror;
using UnityEngine;

namespace RockPaperSpell.Network
{
    public class Wizard : NetworkBehaviour, Interface.Wizard
    {
        [SyncVar(hook = nameof(SetGoldView))] private int gold;
        [SyncVar(hook = nameof(SetPositionView))] private int position;
        [SyncVar(hook = nameof(SetSpellView))] private Structs.Spell spell;
        [SyncVar(hook = nameof(SetTargetView))] private Structs.Wizard target;

        private Interface.Wizard wizardView;

        public void SetView(Interface.Wizard view)
        {
            wizardView = view;
        }

        public void SetColor(Color color)
        {
            RpcSetColor(color);
        }

        public void SetGold(int gold)
        {
            this.gold = gold;
        }

        public void SetPosition(int position)
        {
            this.position = position;
        }

        public void SetSpell(Structs.Spell spell)
        {
            this.spell = spell;
        }

        public void SetTarget(Structs.Wizard target)
        {
            this.target = target;
        }

        private void SetGoldView(int oldGold, int newGold)
        {
            wizardView?.SetGold(newGold);
        }

        private void SetPositionView(int oldPosition, int newPosition)
        {
            wizardView?.SetPosition(newPosition);
        }

        private void SetSpellView(Structs.Spell oldSpell, Structs.Spell newSpell)
        {
            wizardView?.SetSpell(newSpell);
        }

        private void SetTargetView(Structs.Wizard oldTarget, Structs.Wizard newTarget)
        {
            wizardView?.SetTarget(newTarget);
        }

        [ClientRpc]
        private void RpcSetColor(Color color)
        {
            wizardView.SetColor(color);
        }
    }
}