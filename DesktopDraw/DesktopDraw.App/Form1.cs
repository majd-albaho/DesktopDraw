using DesktopDraw.App.Model;
using DesktopDraw.App.Services;
using System.Numerics;
using System.Runtime.InteropServices;

namespace DesktopDraw.App
{
    public partial class Form1 : Form
    {
        private Thread _drawPreviewThread;
        private Thread _userInputThread;
        private DrawService _drawService;

        private bool beginButtonPressed;
        private bool endButtonPressed;

        private bool loadingPreview;
        private bool loadPreview;
        private bool drawPicture;

        private Image clipboardImage;
        private Vector2 drawBegin, drawEnd;

        private List<Pixel> pixels;
        int waitX = 0, waitY = 2;
        int hotKeyEnd = 0x26; // arrow up key
        int hotKeyStop = 0x1B; // Escape key


        public Form1() {
            InitializeComponent();

            _drawService = new DrawService();
        }

        private void Form1_Load(object sender, EventArgs e) {
            CheckForIllegalCrossThreadCalls = false;
            _userInputThread = new Thread(ProcessUserInput) { IsBackground = true };
            _userInputThread.Start();
        }

        void ProcessUserInput() {
            while (true) {
                if (WindowsApiImplementation.GetAsyncKeyState(hotKeyEnd) < 0) {
                    Application.Exit();
                }

                if (WindowsApiImplementation.GetAsyncKeyState(hotKeyStop) < 0) {
                    drawPicture = false;
                }

                if (beginButtonPressed) {
                    drawBegin = new Vector2(Cursor.Position.X, Cursor.Position.Y);
                }

                if (endButtonPressed) {
                    drawEnd = new Vector2(Cursor.Position.X, Cursor.Position.Y);
                }

                if (loadPreview) {
                    if (!loadingPreview) {
                        LoadImagePreview();
                    }
                }

                Thread.Sleep(100); // Reduce CPU usage
            }
        }


        private void LoadImageFromClipboard(Image image) {
            clipboardImage = image;
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

            pixels = _drawService.ExtractSimilarPixels(recostructImage, Color.Black);
            using (var g = Graphics.FromImage(recostructImage)) {
                g.Clear(Color.White);
            }

            bool skipPixel = false;
            foreach (var pixel in pixels) {
                if (loadPreview) {
                    loadingPreview = false;
                    return;
                }

                if (!skipPixel) {
                    recostructImage.SetPixel(pixel.X, pixel.Y, Color.Black);
                }
                skipPixel = !skipPixel;
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

            LoadImageFromClipboard(cImage);
        }

        private void button2_Click(object sender, EventArgs e) {
            if (clipboardImage == null)
                return;

            if (drawBegin != Vector2.Zero && drawEnd != Vector2.Zero) {
                if (_drawPreviewThread == null) {
                    _drawPreviewThread = new Thread(DrawImageOnScreen) { IsBackground = true };
                }

                _drawPreviewThread.Start();
            }
        }

        public void DrawImageOnScreen() {
            drawPicture = true;

            var imagePixels = _drawService.GetImagePixels(drawBegin, drawEnd, clipboardImage);

            bool skipPixel = false;
            int x = 0; int y = 0;
            foreach (var pixel in imagePixels) {
                if (!drawPicture)
                    return;

                if (!skipPixel) {
                    WindowsApiImplementation.SetCursorPos((int)drawBegin.X + pixel.X, (int)drawBegin.Y + pixel.Y);
                    WindowsApiImplementation.mouse_event(WindowsApiImplementation.MOUSELEFTDOWN | WindowsApiImplementation.MOUSELEFTUP, 0, 0, 0, UIntPtr.Zero);
                }

                if (pixel.Y > y) {
                    y = pixel.Y;
                    x = 0;
                    Thread.Sleep(waitY);
                }

                if (pixel.X > x) {
                    x = pixel.X;
                    Thread.Sleep(waitX);
                }
                skipPixel = !skipPixel;
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
    }
}
