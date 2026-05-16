using System.Numerics;
using System.Runtime.InteropServices;

namespace DesktopDraw.App
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(int vKey);

        [DllImport("user32.dll")]
        public static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        public static extern void mouse_event(uint dwFlags, int dx, int dy, uint dwData, UIntPtr dwExtraInfo);


        private const int MOUSELEFTDOWN = 0x02;
        private const int MOUSELEFTUP = 0x04;

        private bool beginButtonPressed;
        private bool endButtonPressed;

        private bool loadingPreview;
        private bool loadPreview;
        private bool drawPicture;

        private Image clipboardImage;
        private Vector2 drawBegin, drawEnd;

        private List<Pixel> pixels;
        int allowDifferences = 75;
        int waitX = 0, waitY = 40;
        int hotKeyEnd = 0x26; // Up Arrow Key
        int hotKeyStop = 0x27; // Right Arrow Key


        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            CheckForIllegalCrossThreadCalls = false;
            var userInputThread = new Thread(ProcessUserInput) { IsBackground = true };
            userInputThread.Start();
        }

        private bool AreColorsSimilar(Color c1, Color c2, int maxColorDifference) {
            int rDiff = Math.Abs(c1.R - c2.R);
            int gDiff = Math.Abs(c1.G - c2.G);
            int bDiff = Math.Abs(c1.B - c2.B);
            return rDiff <= maxColorDifference && gDiff <= maxColorDifference && bDiff <= maxColorDifference;
        }

        private List<Pixel> ExtractSimilarPixels(Bitmap bitmap, Color targetColor, int maxColorDifference) {
            List<Pixel> pixels = new List<Pixel>();

            for (int i = 0; i < bitmap.Width; i++) {
                for (int j = 0; j < bitmap.Height; j++) {
                    var pixelColor = bitmap.GetPixel(i, j);
                    if (AreColorsSimilar(pixelColor, targetColor, maxColorDifference)) {
                        pixels.Add(new Pixel(i, j, pixelColor));
                    }
                }
            }
            return pixels;
        }

        private void DrawImageOnScreen() {
            drawPicture = true;

            var newWidth = (int)(drawEnd.X - drawBegin.X);
            var newHeight = (int)(drawEnd.Y - drawBegin.Y);

            var resizedImage = new Bitmap(newWidth, newHeight);
            using (var g = Graphics.FromImage(resizedImage)) {
                g.DrawImage(clipboardImage, 0, 0, newWidth, newHeight);
            }

            pixels = ExtractSimilarPixels(resizedImage, Color.Black, allowDifferences);
            pixels = pixels.OrderBy(p => p.Y).ThenBy(p => p.X).ToList();

            int x = 0; int y = 0;
            foreach (var pixel in pixels) {
                if (!drawPicture)
                    return;

                SetCursorPos((int)drawBegin.X + pixel.X, (int)drawBegin.Y + pixel.Y);
                mouse_event(MOUSELEFTDOWN | MOUSELEFTUP, 0, 0, 0, UIntPtr.Zero);

                if (pixel.Y > y) {
                    y = pixel.Y;
                    Thread.Sleep(waitY);
                }

                if (pixel.X > x) {
                    x = pixel.X;
                    Thread.Sleep(waitX);
                }

                if (x == resizedImage.Width) {
                    x = 0;
                }

                //if (GetAsyncKeyState(hotKeyEnd) < 0) {
                //    drawPicture = false;
                //    break;
                //}
                //int screenX = (int)(drawBegin.X + pixel.X);
                //int screenY = (int)(drawBegin.Y + pixel.Y);
                //mouse_event(MOUSELEFTDOWN, screenX, screenY, 0, UIntPtr.Zero);
                //mouse_event(MOUSELEFTUP, screenX, screenY, 0, UIntPtr.Zero);
                //// Optional: Add a small delay to prevent overwhelming the system
                //Thread.Sleep(1);
            }
        }

        private void LoadImageFromClipboard() {
            var cImage = Clipboard.GetImage();
            if (cImage == null) {
                MessageBox.Show("Failed to load image from clipboard.");
                return;
            }

            clipboardImage = cImage;
            previewPictureBox.Image = clipboardImage;
            previewPictureBox.Size = clipboardImage.Size;
            LoadImagePreview();
        }

        private void LoadImagePreview() {
            loadPreview = false;
            loadingPreview = true;

            var recostructImage = new Bitmap(previewPictureBox.Width, previewPictureBox.Height);
            using (var g = Graphics.FromImage(recostructImage)) {
                g.DrawImage(clipboardImage, 0, 0, previewPictureBox.Width, previewPictureBox.Height);
            }

            if (loadPreview) {
                loadingPreview = false;
                return;
            }

            pixels = ExtractSimilarPixels(recostructImage, Color.Black, allowDifferences);
            using (var g = Graphics.FromImage(recostructImage)) {
                g.Clear(Color.White);
            }
            foreach (var pixel in pixels) {
                if (loadPreview) {
                    loadingPreview = false;
                    return;
                }

                recostructImage.SetPixel(pixel.X, pixel.Y, Color.Black);
            }

            drawPictureBox.Invoke(() => {
                drawPictureBox.Image = recostructImage;
                drawPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            });
            loadingPreview = false;
        }

        private void button1_Click(object sender, EventArgs e) {
            var cImage = Clipboard.GetImage();
            if (cImage == null) {
                MessageBox.Show("Failed to load image from clipboard.");
                return;
            }

            clipboardImage = cImage;
            LoadImageFromClipboard();
        }

        private void button2_Click(object sender, EventArgs e) {
            if (clipboardImage == null)
                return;

            if (drawBegin != Vector2.Zero && drawEnd != Vector2.Zero) {
                Thread drawThread = new Thread(DrawImageOnScreen) { IsBackground = true };
                drawThread.Start();
            }
        }

        private void button3_MouseDown(object sender, MouseEventArgs e) {
            beginButtonPressed = true;
            Cursor = Cursors.Cross;
        }

        private void button3_MouseUp(object sender, MouseEventArgs e) {
            beginButtonPressed = false;
            Cursor = Cursors.Default;
        }

        private void button4_MouseDown(object sender, MouseEventArgs e) {
            endButtonPressed = true;
            Cursor = Cursors.Cross;
        }

        private void button4_MouseUp(object sender, MouseEventArgs e) {
            endButtonPressed = false;
            Cursor = Cursors.Default;
        }


        void ProcessUserInput() {
            while (true) {
                if (GetAsyncKeyState(hotKeyEnd) < 0) {
                    Application.Exit();
                }

                if (GetAsyncKeyState(hotKeyStop) < 0) {
                    drawPicture = false;
                }

                if (beginButtonPressed) {
                    drawBegin = new Vector2(Cursor.Position.X, Cursor.Position.Y);
                    drawBeginTxtBox.Text = drawBegin.ToString();
                }

                if (endButtonPressed) {
                    drawEnd = new Vector2(Cursor.Position.X, Cursor.Position.Y);
                    drawEndTxtBox.Text = drawEnd.ToString();
                }

                if (loadPreview) {
                    if (!loadingPreview) {
                        LoadImagePreview();
                    }
                }

                Thread.Sleep(100); // Reduce CPU usage
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e) {
            waitX = trackBar1.Value;
        }

        private void trackBar2_Scroll(object sender, EventArgs e) {
            waitY = trackBar2.Value;
        }
    }
}
