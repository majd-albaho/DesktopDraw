using DesktopDraw.App.Model;
using System.Numerics;

namespace DesktopDraw.App.Services
{
    internal class DrawService
    {
        int allowDifferences = 75;

        public List<Pixel> GetImagePixels(Vector2 drawBegin, Vector2 drawEnd, Image clipboardImage) {
            var newWidth = (int)(drawEnd.X - drawBegin.X);
            var newHeight = (int)(drawEnd.Y - drawBegin.Y);

            var resizedImage = new Bitmap(newWidth, newHeight);
            using (var g = Graphics.FromImage(resizedImage)) {
                g.DrawImage(clipboardImage, 0, 0, newWidth, newHeight);
            }

            return ExtractSimilarPixels(resizedImage, Color.Black).OrderBy(p => p.Y).ThenBy(p => p.X).ToList();
        }

        public List<Pixel> ExtractSimilarPixels(Bitmap bitmap, Color targetColor) {
            List<Pixel> pixels = new List<Pixel>();

            for (int i = 0; i < bitmap.Width; i++) {
                for (int j = 0; j < bitmap.Height; j++) {
                    var pixelColor = bitmap.GetPixel(i, j);
                    if (AreColorsSimilar(pixelColor, targetColor, allowDifferences)) {
                        pixels.Add(new Pixel(i, j, pixelColor));
                    }
                }
            }
            return pixels;
        }

        private bool AreColorsSimilar(Color c1, Color c2, int maxColorDifference) {
            int rDiff = Math.Abs(c1.R - c2.R);
            int gDiff = Math.Abs(c1.G - c2.G);
            int bDiff = Math.Abs(c1.B - c2.B);
            return rDiff <= maxColorDifference && gDiff <= maxColorDifference && bDiff <= maxColorDifference;
        }
    }
}
