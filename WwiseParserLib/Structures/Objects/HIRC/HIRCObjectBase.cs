﻿using System;
using System.Collections.Generic;

namespace WwiseParserLib.Structures.Objects.HIRC
{
    /// <summary>
    /// The base class of all HIRC section Wwise object structures.
    /// </summary>
    public abstract class HIRCObjectBase : WwiseObjectBase
    {
        private HIRCObjectBase()
        {

        }

        protected HIRCObjectBase(HIRCObjectType type, uint length)
        {
            Type = type;
            Length = length;
        }

        /// <summary>
        /// The type of the object.
        /// </summary>
        public HIRCObjectType Type { get; private set; }

        /// <summary>
        /// The length of the object, in bytes, excluding the type and the length.
        /// </summary>
        public uint Length { get; set; }

        /// <summary>
        /// The ID of the object.
        /// </summary>
        public uint Id { get; set; }

        public override bool Equals(object obj)
        {
            return obj is HIRCObjectBase @base &&
                   Type == @base.Type &&
                   Id == @base.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Type, Id);
        }

        public static bool operator ==(HIRCObjectBase left, HIRCObjectBase right)
        {
            return EqualityComparer<HIRCObjectBase>.Default.Equals(left, right);
        }

        public static bool operator !=(HIRCObjectBase left, HIRCObjectBase right)
        {
            return !(left == right);
        }
    }

    public enum HIRCObjectType : byte
    {
        Unknown,
        Settings,
        Sound, // 0x2
        EventAction, //0x3
        Event, //0x4
        Container, //0x5
        SwitchContainer, //0x6
        ActorMixer, // 0x7
        AudioBus, //0x8
        BlendContainer, //0x9
        MusicSegment, //0xA
        MusicTrack, // 0xB
        MusicSwitchContainer, //0xC
        MusicPlaylistContainer, //0xD
        Attenuation, // 0x0E
        DialogueEvent, //0xF
        
        // These don't match Wwiser code, not sure source of these
        MotionBus, // 0x10 - Wwiser code differs starting here depending on bank version
        MotionEffect, // 0x11
        Effect, // 0x12
        Unknown_0x13,
        AuxiliaryBus
    }
}
