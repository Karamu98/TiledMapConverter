using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing;

namespace TiledConverter
{
    namespace DataStructures
    {
        [System.Serializable]
        public class TiledMap
        {
            public int height;
            public int width;
            public Layer[] layers;
            public int tileheight;
            public int tilewidth;

            public struct Layer
            {
                public int[] data;
                public int height;
                public int width;
                public int id;
                public string name;
            }
        }

        [System.Serializable]
        public class TiledTileMap
        {
            public Tiles[] tiles;

            public class Tiles
            {
                public int id;
                public Properties[] properties;

                public struct Properties
                {
                    public string name;
                }
            }
        }

        [System.Serializable]
        public class CompressedMap
        {
            public CompressedMap(TiledMap map, TiledTileMap tileMap, string imgFilePath)
            {
                try
                {
                    m_width = (byte)map.width;
                    m_height = (byte)map.height;
                    m_tileWidth = (byte)map.tilewidth;
                    m_tileHeight = (byte)map.tileheight;
                    m_imgFilePath = imgFilePath;

                    int[] staticLayer = map.layers[0].data;
                    int[] dynamicLayer = map.layers[1].data;

                    char[] newData = new char[map.layers[0].data.Length];
                    List<TiledTileMap.Tiles> lookupList = tileMap.tiles.ToList();

                    for(int i = 0; i < staticLayer.Length; ++i)
                    {
                        int currentTileValue = staticLayer[i] - 1; // Exported ID's aren't 0 based, fixing here with -1

                        // Check dynamics
                        if (i < dynamicLayer.Length)
                        {
                            if(dynamicLayer[i] != 0)
                            {
                                currentTileValue = dynamicLayer[i] - 1;
                            }
                        }

                        TiledTileMap.Tiles tile = lookupList.Find(x => x.id == currentTileValue);
                        if (tile == null)
                        {
                            throw new Exception($"Tile map does not contain id: {currentTileValue}.");
                        }

                        newData[i] = (tile.properties[0].name[0]);
                    }

                    m_data = newData.ToArray();
                }
                catch(Exception e)
                {
                    throw new Exception($"Bad structure. \n{e}");
                }
            }

            public bool WriteToFile(string filePath)
            {
                try
                {
                    using (FileStream outFS = new FileStream(filePath, FileMode.Create))
                    {
                        using (FileStream inFS = new FileStream(m_imgFilePath, FileMode.Open))
                        {
                            byte[] imgFile = new byte[inFS.Length];
                            inFS.Read(imgFile, 0, Convert.ToInt32(inFS.Length));

                            outFS.Write(imgFile, 0, imgFile.Length);
                        }

                        byte[] bytes = GetByteArray();
                        outFS.Write(bytes, 0, bytes.Length);

                        return true;
                    }
                }
                catch(Exception e)
                {
                }

                return false;
            }

            private byte[] GetByteArray()
            {
                byte[] ret = null;
                using (MemoryStream m = new MemoryStream())
                {
                    using (BinaryWriter writer = new BinaryWriter(m))
                    {
                        writer.Write(m_data);
                        writer.Write(m_tileHeight);
                        writer.Write(m_tileWidth);
                        writer.Write(m_height);
                        writer.Write(m_width);
                    }
                    ret = m.ToArray();
                }
                return ret;
            }

            public void PrettyPrint(string filePath)
            {
                string file = $"W: {m_width} H: {m_height}\nTile W: {m_tileWidth} H: {m_tileHeight}\n";

                for(int i = 0; i < m_data.Length; ++i)
                {
                    if (i != 0 && i % m_width == 0)
                    {
                        file += '\n';
                    }

                    file += m_data[i];
                }

                string dir = Path.GetDirectoryName(filePath);
                string fileName = Path.GetFileNameWithoutExtension(filePath);

                File.WriteAllText($"{dir}\\{fileName}.txt", file, Encoding.ASCII);
            }

            public byte m_width;
            public byte m_height;
            public byte m_tileWidth;
            public byte m_tileHeight;
            public char[] m_data;
            public string m_imgFilePath;
        }

    }
}
