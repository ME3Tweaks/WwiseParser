using System;
using System.Collections.Generic;
using System.Text;

namespace WwiseParserLib.Structures.Objects.HIRC
{
    internal class Attenuation : HIRCObjectBase
    {
        public Attenuation(uint length) : base(HIRCObjectType.Attenuation, length)
        {
        }

        public bool bIsConeEnabled { get; set; }
        public byte[] curveToUse { get; set; }
        public byte NumCurves { get; set; }
        public ConversionTable[] ConversionTables { get; set; }
        public ushort numRTPC { get; set; }
    }

    internal class ConversionTable
    {
        public byte eScaling { get; set; }
        public ushort ulSize { get; set; }
        public RTPCGraphPoint[] GraphPoints { get; set; }
    }

    internal class RTPCGraphPoint
    {
        public float From { get; set; }
        public float To { get; set; }
        public uint Interp { get; set; }
    }
}
