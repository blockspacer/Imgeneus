﻿using BinarySerialization;
using Imgeneus.Database.Entities;
using Imgeneus.Network.Serialization;
using System.Linq;

namespace Imgeneus.World.Serialization.EP_5
{
    /// <summary>
    /// Serializer for character selection screen.
    /// </summary>
    public class CharacterSelectionScreen_EP5 : BaseSerializable
    {
        [FieldOrder(0)]
        public int CharacterId;

        [FieldOrder(1)]
        public int Unknown; // possibly date of creation

        [FieldOrder(2)]
        public ushort Level;

        [FieldOrder(3)]
        public Race Race;

        [FieldOrder(4)]
        public Mode Mode;

        [FieldOrder(5)]
        public byte Hair;

        [FieldOrder(6)]
        public byte Face;

        [FieldOrder(7)]
        public byte Height;

        [FieldOrder(8)]
        public CharacterProfession Class;

        [FieldOrder(9)]
        public Gender Gender;

        [FieldOrder(10)]
        public ushort Map;

        [FieldOrder(11)]
        public ushort Strength;

        [FieldOrder(12)]
        public ushort Dexterity;

        [FieldOrder(13)]
        public ushort Rec;

        [FieldOrder(14)]
        public ushort Intelligence;

        [FieldOrder(15)]
        public ushort Wisdom;

        [FieldOrder(16)]
        public ushort Luck;

        [FieldOrder(17)]
        public ushort HealthPoints;

        [FieldOrder(18)]
        public ushort ManaPoints;

        [FieldOrder(19)]
        public ushort StaminaPoints;

        [FieldOrder(20)]
        public byte[] EquipmentItemsType = new byte[8];

        [FieldOrder(21)]
        public byte[] EquipmentItemsTypeId = new byte[8];

        [FieldOrder(22)]
        public string Name;

        [FieldOrder(23)]
        public byte[] CapeInfo = new byte[6];

        public CharacterSelectionScreen_EP5(DbCharacter character)
        {
            CharacterId = character.Id;
            Level = character.Level;
            Race = character.Race;
            Mode = character.Mode;
            Hair = character.Hair;
            Face = character.Face;
            Height = character.Height;
            Class = character.Class;
            Gender = character.Gender;
            Map = character.Map;
            Strength = character.Strength;
            Dexterity = character.Dexterity;
            Rec = character.Rec;
            Intelligence = character.Intelligence;
            Wisdom = character.Wisdom;
            Luck = character.Luck;

            var equipmentItems = character.Items.Where(item => item.Bag == 0);

            for (var i = 0; i < 8; i++)
            {
                var item = equipmentItems.FirstOrDefault(itm => itm.Slot == i);
                if (item is null)
                {
                    EquipmentItemsType[i] = 0;
                    EquipmentItemsTypeId[i] = 0;
                }
                else
                {
                    EquipmentItemsType[i] = item.Type;
                    EquipmentItemsTypeId[i] = item.TypeId;
                }
            }

            Name = character.Name.PadRight(21);
        }
    }
}
