using FileHelpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KMeans_Test {
    public partial class MainWindow : Form {
        private Bitmap GraphicsImage;

        private Int32 numOfTerminus;
        private Random random;
        private City[] cities;
        private Centroid[] centroids;

        private float maxLeft;
        private float maxRight;
        private float maxTop;
        private float maxBottom;

        private float leftMost;
        private float rightMost;
        private float topMost;
        private float bottomMost;

        public MainWindow() {
            InitializeComponent();

            this.GraphicsImage = new Bitmap(DrawingPanel.Width, DrawingPanel.Height, PixelFormat.Format24bppRgb);
            initGraphicsImage();

            this.openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            this.saveImageDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            this.saveResultDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }

        private void MainWindow_Activated(object sender, EventArgs e) {
            this.browseButton.Focus();
        }

        private void initGraphicsImage() {
            Graphics.FromImage(GraphicsImage).Clear(Color.White);
            DrawingPanel.CreateGraphics().DrawImageUnscaled(GraphicsImage, new Point(0, 0));
        }

        private void initVariables() {
            this.numOfTerminus = 0;
            this.random = new Random();
            this.cities = null;
            this.centroids = null;

            this.maxLeft = 0.0f;
            this.maxRight = 0.0f;
            this.maxTop = 0.0f;
            this.maxBottom = 0.0f;

            this.leftMost = 0.0f;
            this.rightMost = 0.0f;
            this.topMost = 0.0f;
            this.bottomMost = 0.0f;
        }

        private Boolean parseInput() {
            try {
                FileHelperEngine engine = new FileHelperEngine(typeof(City));

                this.cities = engine.ReadFile(this.fileDirectoryTextBox.Text) as City[];
                this.numOfTerminus = cities.Length;

                return true;
            } catch (Exception e) {
                String content = e.ToString();

                content = "Error reading from file:\n" + this.fileDirectoryTextBox.Text + "\n\n";
                content += "The file might be corrupted or poorly formatted.";

                MessageBox.Show(content, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                return false;
            }
        }

        private float convertToDecimal(Int32 degree, Int32 minute) {
            float result = degree;
            result += minute / 60.0f;

            return result;
        }

        private Point convertToLocationOnDrawingPanel(City c) {
            float widthMagicNumber = (maxRight - maxLeft) / (rightMost - leftMost);
            float heightMagicNumber = (maxBottom - maxTop) / (bottomMost - topMost);

            float distanceFromLeft = convertToDecimal(c.derajatBujur, c.menitBujur) * (c.bujurBaratTimur.Equals("T") ? 1 : -1) - leftMost;
            float distanceFromTop = convertToDecimal(c.derajatLintang, c.menitLintang) * (c.lintangUtaraSelatan.Equals("U") ? 1 : -1) - topMost;

            Point locationOnDrawingPanel = new Point(0, 0);
            locationOnDrawingPanel.X = (Int32)Math.Round(maxLeft + distanceFromLeft * widthMagicNumber);
            locationOnDrawingPanel.Y = (Int32)Math.Round(maxTop + distanceFromTop * heightMagicNumber);

            return locationOnDrawingPanel;
        }

        private Point convertToLocationOnDrawingPanel(PointF p) {
            float widthMagicNumber = (maxRight - maxLeft) / (rightMost - leftMost);
            float heightMagicNumber = (maxBottom - maxTop) / (bottomMost - topMost);

            float distanceFromLeft = p.X - leftMost;
            float distanceFromTop = p.Y - topMost;

            Point locationOnDrawingPanel = new Point(0, 0);
            locationOnDrawingPanel.X = (Int32)Math.Round(maxLeft + distanceFromLeft * widthMagicNumber);
            locationOnDrawingPanel.Y = (Int32)Math.Round(maxTop + distanceFromTop * heightMagicNumber);

            return locationOnDrawingPanel;
        }

        private Point convertToLocationOnDrawingPanel(Centroid c) {
            float widthMagicNumber = (maxRight - maxLeft) / (rightMost - leftMost);
            float heightMagicNumber = (maxBottom - maxTop) / (bottomMost - topMost);

            float distanceFromLeft = c.location.X - leftMost;
            float distanceFromTop = c.location.Y - topMost;

            Point locationOnDrawingPanel = new Point(0, 0);
            locationOnDrawingPanel.X = (Int32)Math.Round(maxLeft + distanceFromLeft * widthMagicNumber);
            locationOnDrawingPanel.Y = (Int32)Math.Round(maxTop + distanceFromTop * heightMagicNumber);

            return locationOnDrawingPanel;
        }

        private float calculateEuclideanDistance(PointF a, PointF b) {
            float result = (a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y);
            return (float)Math.Sqrt(result);
        }

        private void doComputation() {
            initGraphicsImage();

            // Determine Drawing Area
            maxLeft = 15.0f;
            maxRight = this.DrawingPanel.Size.Width - 20.0f;
            maxTop = 15.0f;
            maxBottom = this.DrawingPanel.Size.Height - 20.0f;

            // Determine Boundries From Data
            leftMost = convertToDecimal(cities[0].derajatBujur, cities[0].menitBujur);
            if (cities[0].bujurBaratTimur.Equals("B")) leftMost *= -1.0f;
            rightMost = leftMost;

            topMost = convertToDecimal(cities[0].derajatLintang, cities[0].menitLintang);
            if (cities[0].lintangUtaraSelatan.Equals("S")) topMost *= -1.0f;
            bottomMost = topMost;

            foreach (City c in cities) {
                float bujur = convertToDecimal(c.derajatBujur, c.menitBujur);
                if (c.bujurBaratTimur.Equals("B")) bujur *= -1.0f;

                float lintang = convertToDecimal(c.derajatLintang, c.menitLintang);
                if (c.lintangUtaraSelatan.Equals("S")) lintang *= -1.0f;

                if (bujur < leftMost) leftMost = bujur;
                if (bujur > rightMost) rightMost = bujur;

                if (lintang > topMost) topMost = lintang;
                if (lintang < bottomMost) bottomMost = lintang;
            }

            // Initialize Centroids with random value
            if (centroids == null) {
                centroids = new Centroid[numOfTerminus];

                for (Int32 i = 0; i < centroids.Length; i++) {
                    centroids[i] = new Centroid();

                    PointF location = new PointF(0.0f, 0.0f);
                    location.X = (float)random.NextDouble() * (rightMost - leftMost) + leftMost;
                    location.Y = (float)random.NextDouble() * (topMost - bottomMost) + bottomMost;
                    centroids[i].location = location;

                    centroids[i].color = ColorHelper.getNextKnownColor();
                }
            }

            // Determine Closest Distance
            foreach (Centroid c in centroids) c.closestCities.Clear();
            foreach (City c in cities) {
                Int32 i = 0, closestCentroid = Int32.MinValue;
                float minDistance = float.MaxValue;

                do {
                    PointF cityLocationOnMap = new PointF(0.0f, 0.0f);
                    cityLocationOnMap.X = convertToDecimal(c.derajatBujur, c.menitBujur) * (c.bujurBaratTimur.Equals("T") ? 1.0f : -1.0f);
                    cityLocationOnMap.Y = convertToDecimal(c.derajatLintang, c.menitLintang) * (c.lintangUtaraSelatan.Equals("U") ? 1.0f : -1.0f);

                    if (minDistance > calculateEuclideanDistance(cityLocationOnMap, centroids[i].location)) {
                        closestCentroid = i;
                        minDistance = calculateEuclideanDistance(cityLocationOnMap, centroids[i].location);
                    }
                } while (++i < centroids.Length);

                centroids[closestCentroid].closestCities.Add(c);
            }

            // Draw The Cities And Centroids
            Graphics DrawingGraphics = Graphics.FromImage(GraphicsImage);
            DrawingGraphics.SmoothingMode = SmoothingMode.HighQuality;

            foreach (Centroid p in centroids) {
                foreach (City c in p.closestCities) {
                    Point cityLocationOnDrawingPanel = convertToLocationOnDrawingPanel(c);
                    DrawingGraphics.FillEllipse(new SolidBrush(p.color), cityLocationOnDrawingPanel.X, cityLocationOnDrawingPanel.Y, 10, 10);
                }

                maxRight -= 5.0f;
                maxBottom -= 5.0f;

                Point centroidLocationOnDrawingPanel = convertToLocationOnDrawingPanel(p);
                DrawingGraphics.FillRectangle(new SolidBrush(p.color), centroidLocationOnDrawingPanel.X, centroidLocationOnDrawingPanel.Y, 15, 15);

                maxRight += 5.0f;
                maxBottom += 5.0f;
            }

            DrawingPanel.CreateGraphics().DrawImageUnscaled(GraphicsImage, new Point(0, 0));

            // Calculate Next Centroid
            String serializedOldCentroid = JsonConvert.SerializeObject(centroids);
            Centroid[] oldCentroid = JsonConvert.DeserializeObject<Centroid[]>(serializedOldCentroid);
            foreach (Centroid centroid in centroids) {
                PointF rata2 = new PointF(0.0f, 0.0f);

                foreach (City city in centroid.closestCities) {
                    PointF location = new PointF(0.0f, 0.0f);
                    location.X = convertToDecimal(city.derajatBujur, city.menitBujur) * (city.bujurBaratTimur.Equals("T") ? 1.0f : -1.0f);
                    location.Y = convertToDecimal(city.derajatLintang, city.menitLintang) * (city.lintangUtaraSelatan.Equals("U") ? 1.0f : -1.0f);

                    rata2.X += location.X;
                    rata2.Y += location.Y;
                }

                if (centroid.closestCities.Count != 0 || true) {
                    rata2.X = rata2.X / (float)centroid.closestCities.Count;
                    rata2.Y = rata2.Y / (float)centroid.closestCities.Count;
                } else {
                    // Push ke centroid lain yg terdekat

                }

                centroid.location = rata2;
            }

            // Check Program Ends
            Boolean centroidLocationChange = false;

            for (Int32 i = 0; i < centroids.Length; i++) {
                Point a = convertToLocationOnDrawingPanel(centroids[i].location);
                Point b = convertToLocationOnDrawingPanel(oldCentroid[i].location);

                if (a.X != b.X && a.Y != b.Y) {
                    centroidLocationChange = true;
                    break;
                }
            }

            if (!centroidLocationChange) {
                timer.Stop();
                // Enable UI Elements
                this.browseButton.Enabled = true;
                this.numOfTerminusComboBox.Enabled = true;
                this.calcButton.Enabled = true;
                this.saveResultButton.Enabled = true;
                this.saveImageButton.Enabled = true;

                // Print Output
                Array.Sort(centroids);
                for (Int32 i = 0; i < centroids.Length; i++) {
                    PointF p = centroids[i].location;

                    String utaraSelatan = p.Y >= 0.0f ? "U" : "S";
                    String baratTimur = p.X >= 0.0f ? "T" : "B";

                    p.X = Math.Abs(p.X);
                    p.Y = Math.Abs(p.Y);

                    String printedContent = "Station " + (i + 1) + ": ";

                    printedContent += Math.Truncate(p.Y);
                    printedContent += (Char)176;
                    p.Y -= (float)Math.Truncate(p.Y);
                    p.Y *= 60.0f;
                    printedContent += Math.Truncate(p.Y) + "\'";
                    printedContent += utaraSelatan + " ";

                    printedContent += Math.Truncate(p.X);
                    printedContent += (Char)176;
                    p.X -= (float)Math.Truncate(p.X);
                    p.X *= 60.0f;
                    printedContent += Math.Truncate(p.X) + "\'";
                    printedContent += baratTimur + Environment.NewLine;

                    this.resultRichTextBox.AppendText(printedContent);
                }
            }
        }

        private void DrawingPanel_Paint(object sender, PaintEventArgs e) {
            e.Graphics.DrawImageUnscaled(GraphicsImage, new Point(0, 0));
        }

        private void aboutButton_Click(object sender, EventArgs e) {
            String content = "Bus Station Positioning System\n";
            content += "-----------------------------------\n";
            content += "\nCreated by: Jason Wihardja";

            MessageBox.Show(content, "About", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e) {
            initVariables();
            initGraphicsImage();

            this.fileDirectoryTextBox.Text = this.openFileDialog.FileName;

            if (parseInput()) {
                this.numOfTerminusComboBox.Enabled = true;
                this.numOfTerminusComboBox.Items.Clear();

                for (Int32 i = 1; i <= numOfTerminus; i++) {
                    this.numOfTerminusComboBox.Items.Add(i);
                }
                this.numOfTerminusComboBox.SelectedIndex = 0;

                this.calcButton.Enabled = true;
            }
        }

        private void saveResultButton_Click(object sender, EventArgs e) {
            this.saveResultDialog.ShowDialog(this);
        }

        private void saveImageDialog_FileOk(object sender, CancelEventArgs e) {
            GraphicsImage.Save(saveImageDialog.FileName, ImageFormat.Bmp);
        }

        private void browseButton_Click(object sender, EventArgs e) {
            this.openFileDialog.ShowDialog(this);
        }

        private void calcButton_Click(object sender, EventArgs e) {
            this.numOfTerminus = (Int32)this.numOfTerminusComboBox.SelectedItem;
            this.centroids = null;

            this.resultRichTextBox.Clear();

            // Disable UI Elements
            this.browseButton.Enabled = false;
            this.numOfTerminusComboBox.Enabled = false;
            this.calcButton.Enabled = false;
            this.saveResultButton.Enabled = false;
            this.saveImageButton.Enabled = false;

            this.timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e) {
            doComputation();
        }

        private void saveImageButton_Click(object sender, EventArgs e) {
            this.saveImageDialog.ShowDialog(this);
        }

        private void saveResultDialog_FileOk(object sender, CancelEventArgs e) {
            File.WriteAllText(this.saveResultDialog.FileName, this.resultRichTextBox.Text, Encoding.UTF8);
        }
    }
}
