using System.IO.Compression;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct MovementPacket {
    public byte Opcode;  // 0x10
    public ushort X;
    public ushort Y;
    public byte Direction;
}

public class PacketCompressor {
    public static byte[] Compress(byte[] data) {
        using (var output = new MemoryStream()) {
            using (var compressor = new DeflateStream(output, CompressionLevel.Optimal)) {
                compressor.Write(data, 0, data.Length);
            }
            return output.ToArray();
        }
    }
}