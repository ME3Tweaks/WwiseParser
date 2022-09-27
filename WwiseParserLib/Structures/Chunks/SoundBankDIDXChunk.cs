using System;
using System.Collections.Generic;
using System.Text;

namespace WwiseParserLib.Structures.Chunks
{
    /// <summary>
    /// STID chunk containing SoundBank ID to name mappings.
    /// </summary>
    public class SoundBankDIDXChunk : SoundBankChunk
    {
        /// <summary>
        /// Creates a new STID chunk.
        /// </summary>
        /// <param name="length">The data length of the chunk excluding the type magic.</param>
        public SoundBankDIDXChunk(int length) : base(SoundBankChunkType.STID, (uint)length)
        {

        }

        /// <summary>
        /// SoundBank ID to name mappings.
        /// </summary>
        public DIDXEntry[] Entries { get; set; }
    }

    /// <summary>
    /// An entry in the DIDX chunk
    /// </summary>
    public class DIDXEntry
    {
        /// <summary>
        /// The ID of the entry this is referencing
        /// </summary>
        public uint Id { get; set; }

        /// <summary>
        /// The offset in the bank to find the info (this is signed, so max bank size is 2GiB)
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// The size of the referenced item
        /// </summary>
        public uint Size { get; set; }
    }
}
