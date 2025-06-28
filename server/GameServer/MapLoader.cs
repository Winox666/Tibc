using System.IO;

public class OTBMParser {
    public static Map Load(string path) {
        using (var stream = new BinaryReader(File.OpenRead(path))) {
            if (stream.ReadUInt32() != 0x4D42544F) // "OTBM"
                throw new Exception("Formato inválido");
            var version = stream.ReadUInt16();
            var width = stream.ReadUInt16();
            var height = stream.ReadUInt16();
            var map = new Map(width, height);
            // Lógica para leer tiles...
            return map;
        }
    }
}