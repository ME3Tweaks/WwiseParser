using System.IO;
using System.Text;
using WwiseParserLib.Structures.Chunks;

namespace WwiseParserLib.Parsers
{
    /// <summary>
    /// Parser for DIDX (Table of contents for data in bank) chunks.
    /// </summary>
    public static class DIDXParser
    {
        public static SoundBankDIDXChunk Parse(byte[] blob)
        {
            using (var reader = new BinaryReader(new MemoryStream(blob)))
            {
                var didxSection = new SoundBankDIDXChunk(blob.Length);
                didxSection.Entries = new DIDXEntry[blob.Length / 12]; // DIDX entry is 12 bytes
                for (int i = 0; i < didxSection.Entries.Length; i++)
                {
                    didxSection.Entries[i] = new DIDXEntry()
                    {
                        Id = reader.ReadUInt32(),
                        Offset = reader.ReadInt32(),
                        Size = reader.ReadUInt32()
                    };
                }
                return didxSection;
            }
        }
    }
}
