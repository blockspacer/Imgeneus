﻿using System;
using System.Collections.Generic;
using Imgeneus.Network.Data;
using Imgeneus.Network.Packets;
using Imgeneus.Network.Serialization;
using Imgeneus.World.Game.Monster;
using Imgeneus.World.Game.Player;
using Imgeneus.World.Serialization;

namespace Imgeneus.World.Packets
{
    internal class CharacterPacketsHelper
    {
        internal void SendInventoryItems(WorldClient client, List<Item> inventoryItems)
        {
            using var packet = new Packet(PacketType.CHARACTER_ITEMS);
            packet.Write(new InventoryItems(inventoryItems).Serialize());
            client.SendPacket(packet);
        }

        internal void SendCurrentHitpoints(WorldClient client, Character character)
        {
            using var packet = new Packet(PacketType.CHARACTER_CURRENT_HITPOINTS);
            packet.Write(new CharacterHitpoints(character).Serialize());
            client.SendPacket(packet);
        }

        internal void SendDetails(WorldClient client, Character character)
        {
            using var packet = new Packet(PacketType.CHARACTER_DETAILS);
            packet.Write(new CharacterDetails(character).Serialize());
            client.SendPacket(packet);
        }

        internal void SendLearnedNewSkill(WorldClient client, bool success)
        {
            using var answerPacket = new Packet(PacketType.LEARN_NEW_SKILL);

            // TODO: refactor it later.
            if (success)
            {
                answerPacket.Write(0);
            }
            else
            {
                answerPacket.Write(1);
            }

            client.SendPacket(answerPacket);
        }

        internal void SendLearnedSkills(WorldClient client, Character character)
        {
            using var packet = new Packet(PacketType.CHARACTER_SKILLS);
            packet.Write(new CharacterSkills(character).Serialize());
            client.SendPacket(packet);
        }

        internal void SendActiveBuffs(WorldClient client, List<ActiveBuff> activeBuffs)
        {
            using var packet = new Packet(PacketType.CHARACTER_ACTIVE_BUFFS);
            packet.Write(new CharacterActiveBuffs(activeBuffs).Serialize());
            client.SendPacket(packet);
        }

        internal void SendNewActiveBuff(WorldClient client, ActiveBuff buff)
        {
            using var packet = new Packet(PacketType.BUFF_SELF);
            packet.Write(new SerializedActiveBuff(buff).Serialize());
            client.SendPacket(packet);
        }

        internal void SendMoveItemInInventory(WorldClient client, Item sourceItem, Item destinationItem)
        {
            // Send move item.
            using var packet = new Packet(PacketType.INVENTORY_MOVE_ITEM);

            var bytes = new SerializedMovedItem(sourceItem).Serialize();
            packet.Write(bytes);

            bytes = new SerializedMovedItem(destinationItem).Serialize();
            packet.Write(bytes);

            client.SendPacket(packet);
        }

        internal void SetMobInTarget(WorldClient client, Mob target)
        {
            using var packet = new Packet(PacketType.TARGET_SELECT_MOB);
            packet.Write(new MobInTarget(target).Serialize());
            client.SendPacket(packet);
        }

        internal void SetPlayerInTarget(WorldClient client, Character target)
        {
            using var packet = new Packet(PacketType.TARGET_SELECT_CHARACTER);
            packet.Write(new CharacterInTarget(target).Serialize());
            client.SendPacket(packet);
        }
    }
}
