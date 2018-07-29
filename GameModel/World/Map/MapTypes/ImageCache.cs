using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BlindFPS
{
    /// <summary>
    /// Represents image cache
    /// </summary>
    class ImageCache
    {
        #region Constants
        private const string fileSuffix = ".bin";
        #endregion

        #region Fields
        private string originalFileName;
        #endregion

        #region Constructor
        public ImageCache(string originalFileName)
        {
            this.originalFileName = originalFileName;
        }
        #endregion

        #region Public Methods
        public bool TryLoadMapCache(out AbstractMatterType[,] mapCache, int width, int height)
        {
            mapCache = null;
            FileInfo file = new FileInfo(originalFileName + fileSuffix);
            if (!file.Exists)
                return false;

            AbstractMatterType wall = new MatterTypeWall();
            mapCache = new AbstractMatterType[width, height];

            int x = 0;
            int y = 0;
            using (BinaryReader binaryReader = new BinaryReader(File.Open(originalFileName + fileSuffix, FileMode.Open)))
            {
                int position = 0;
                int length = (int)binaryReader.BaseStream.Length;

                List<bool> boolList = new List<bool>(8);
                for (int i = 0; i < 8; i++)
                    boolList.Add(false);

                while (position < length)
                {
                    byte byteFromFile = binaryReader.ReadByte();

                    WriteByteToBoolList(byteFromFile, boolList);

                    foreach (bool boolean in boolList)
                    {
                        if (boolean)
                            mapCache[x, y] = wall;
                        else
                            mapCache[x, y] = null;

                        x++;
                        if (x == width)
                        {
                            x = 0;
                            y++;
                        }
                    }

                    position += sizeof(byte);
                }
            }

            return true;
        }

        public void SaveCache(AbstractMatterType[,] mapCache, int width, int height)
        {
            using (BinaryWriter binaryWriter = new BinaryWriter(File.Open(originalFileName + fileSuffix, FileMode.Create)))
            {
                List<bool> boolList = new List<bool>();

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        boolList.Add(mapCache[x, y] != null);
                        if (boolList.Count == 8)
                        {
                            binaryWriter.Write(BoolListToByte(boolList));
                            boolList.Clear();
                        }
                    }
                }
            }
        }
        #endregion

        #region Private Methods
        private void WriteByteToBoolList(byte byteNumber, List<bool> boolList)
        {
            byte mask = 1;
            for (int index = 0; index < 8; index++)
            {
                boolList[index] = ((uint)(byteNumber & mask)) != 0;
                mask *= 2;
            }
        }

        private byte BoolListToByte(List<bool> boolList)
        {
            byte byteNumber = 0;
            byte mask = 1;
            foreach (bool boolNumber in boolList)
            {
                if (boolNumber)
                {
                    byteNumber |= mask;
                }
                mask *= 2;
            }
            return byteNumber;
        }
        #endregion
    }
}