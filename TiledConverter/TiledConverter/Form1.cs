using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TiledConverter.DataStructures;

namespace TiledConverter
{
    public partial class Form1 : Form
    {
        const string FileExtension = "png";

        public Form1()
        {
            InitializeComponent();

            ofdMap.Filter = "Tiled map Files (.json)|*.json";
            ofdTile.Filter = "Tiled tilemap Files (.json)|*.json";
            ofdImg.Filter = ".png|*.PNG";

            sfdOut.Filter = $"Kara Map|*.{FileExtension}";
        }

        private void mapBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = ofdMap.ShowDialog();

            if (result == DialogResult.OK)
            {
                if (TryLoadMap(ofdMap.FileName) == null)
                {
                    MessageBox.Show("Invalid map file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    mapPath.Text = ofdMap.FileName;

                    if (string.IsNullOrWhiteSpace(tilePath.Text))
                    {
                        TryAutoCompleteTilePath(Path.GetDirectoryName(ofdMap.FileName));
                    }

                    if (string.IsNullOrWhiteSpace(outPath.Text))
                    {
                        AutoCompleteOutPath(Path.GetDirectoryName(ofdTile.FileName));
                    }
                }
            }
        }

        private void tileBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = ofdTile.ShowDialog();

            if (result == DialogResult.OK)
            {
                if (TryLoadTileMap(ofdTile.FileName) == null)
                {
                    MessageBox.Show("Invalid tile map file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    tilePath.Text = ofdTile.FileName;

                    if (string.IsNullOrWhiteSpace(mapPath.Text))
                    {
                        TryAutoCompleteMapPath(Path.GetDirectoryName(ofdTile.FileName));
                    }

                    if (string.IsNullOrWhiteSpace(outPath.Text))
                    {
                        AutoCompleteOutPath(Path.GetDirectoryName(ofdTile.FileName));
                    }
                }
            }
        }

        private void imgBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = ofdImg.ShowDialog();

            if (result == DialogResult.OK)
            {
                Image img = TryLoadImage(ofdImg.FileName);
                if (img == null)
                {
                    MessageBox.Show("Invalid image.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    imgPath.Text = ofdImg.FileName;

                    if (string.IsNullOrWhiteSpace(mapPath.Text))
                    {
                        TryAutoCompleteMapPath(Path.GetDirectoryName(ofdImg.FileName));
                    }

                    if (string.IsNullOrWhiteSpace(tilePath.Text))
                    {
                        TryAutoCompleteTilePath(Path.GetDirectoryName(ofdImg.FileName));
                    }

                    if (string.IsNullOrWhiteSpace(outPath.Text))
                    {
                        AutoCompleteOutPath(Path.GetDirectoryName(ofdTile.FileName));
                    }
                }

                img.Dispose();
            }
        }

        private void TryAutoCompleteTilePath(string directory)
        {
            string[] files = Directory.GetFiles(directory, "*.json");

            foreach (string file in files)
            {
                // Load to validate
                DataStructures.TiledTileMap tileTiledMap = LoadJObject<DataStructures.TiledTileMap>(file);

                if (tileTiledMap == null || tileTiledMap.tiles == null)
                {

                }
                else
                {
                    ofdTile.FileName = file;
                    tilePath.Text = file;
                }
            }
        }

        private void TryAutoCompleteMapPath(string directory)
        {
            string[] files = Directory.GetFiles(directory, "*.json");

            foreach (string file in files)
            {
                // Load to validate
                DataStructures.TiledMap tileTiledMap = LoadJObject<DataStructures.TiledMap>(file);

                if (tileTiledMap == null || tileTiledMap.layers == null)
                {

                }
                else
                {
                    ofdMap.FileName = file;
                    mapPath.Text = file;
                }
            }
        }

        private void AutoCompleteOutPath(string directory, string filename = "")
        {
            if (string.IsNullOrEmpty(filename))
            {
                filename = $"map.{FileExtension}";
            }

            string filePath = $"{directory}\\Converted\\{filename}";
            sfdOut.FileName = filePath;
            outPath.Text = filePath;
        }

        private T LoadJObject<T>(string filePath)
        {
            T obj = default(T);

            using (StreamReader file = File.OpenText(filePath))
            {
                string text = file.ReadToEnd();
                obj = JsonConvert.DeserializeObject<T>(text);
            }

            return obj;
        }

        private TiledMap TryLoadMap(string filePath)
        {
            // Load to validate
            TiledMap tiledMap = LoadJObject<TiledMap>(filePath);

            if (tiledMap == null || tiledMap.layers == null)
            {
                return null;
            }

            return tiledMap;
        }

        private TiledTileMap TryLoadTileMap(string filePath)
        {
            // Load to validate
            TiledTileMap tiledTileMap = LoadJObject<TiledTileMap>(filePath);

            if (tiledTileMap == null || tiledTileMap.tiles == null)
            {
                return null;
            }

            return tiledTileMap;
        }

        private Image TryLoadImage(string filePath)
        {
            // Load to validate
            return Image.FromFile(filePath);
        }

        private void outBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = sfdOut.ShowDialog();

            if (result == DialogResult.OK)
            {
                outPath.Text = sfdOut.FileName;
            }
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(mapPath.Text) || string.IsNullOrWhiteSpace(tilePath.Text) || string.IsNullOrWhiteSpace(imgPath.Text))
            {
                MessageBox.Show("Please fill all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            TiledMap map = TryLoadMap(mapPath.Text);
            if (map == null)
            {
                MessageBox.Show("Map invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mapPath.Text = "";
                return;
            }

            TiledTileMap tileMap = TryLoadTileMap(tilePath.Text);
            if (tileMap == null)
            {
                MessageBox.Show("Tile map invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tilePath.Text = "";
                return;
            }

            Image img = TryLoadImage(imgPath.Text);
            if (img == null)
            {
                MessageBox.Show("Image invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                imgPath.Text = "";
                return;
            }
            img.Dispose();

            if(string.IsNullOrWhiteSpace(outPath.Text))
            {
                outBrowse_Click(sender, e);
                if(string.IsNullOrWhiteSpace(outPath.Text))
                {
                    return;
                }
            }

            string dir = Path.GetDirectoryName(outPath.Text);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            // Checks done...
            WriteToObject(map, tileMap, imgPath.Text, outPath.Text);
        }

        private void WriteToObject(TiledMap map, TiledTileMap tileMap, string imgFilePath, string outPath)
        {
            CompressedMap compressedMap = new CompressedMap(map, tileMap, imgFilePath);

            if(compressedMap.m_data != null)
            {
                if(isPrettyPrint.Checked)
                {
                    compressedMap.PrettyPrint(outPath);
                }
                
                if(compressedMap.WriteToFile(outPath))
                {
                    MessageBox.Show("Map converted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ResetAll();
                }
                else
                {
                    MessageBox.Show("Failed to write to file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ResetAll()
        {
            mapPath.Text = "";
            tilePath.Text = "";
            imgPath.Text = "";
            outPath.Text = "";

            ofdMap.FileName = "";
            ofdTile.FileName = "";
            ofdImg.FileName = "";
        }
    }
}
