using System.Drawing.Imaging;

var size = new Size(4, 4);
var i = 0;

var total = 1 << size.Width * size.Height;

var outdir = "imgs";
if (!Directory.Exists(outdir)) { Directory.CreateDirectory(outdir); }

for (; i < total; i++)
{
    float[,] imageData = new float[size.Width, size.Height];
    GenerateBinaryImageData(i, ref imageData);
    Bitmap grayscaleImage = GenerateGrayscaleImage(imageData, size.Width, size.Height);
    grayscaleImage.Save(Path.Combine(outdir,$"{i}.jpg"));
}

Bitmap GenerateGrayscaleImage(float[,] data, int width, int height)
{
    Bitmap image = new Bitmap(width, height, PixelFormat.Format8bppIndexed);
    ColorPalette palette = image.Palette;
    for (int i = 0; i < 256; i++)
    {
        palette.Entries[i] = Color.FromArgb(i, i, i);
    }
    image.Palette = palette;

    BitmapData imageData = image.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);

    unsafe
    {
        byte* imagePointer = (byte*)imageData.Scan0;

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                int grayValue = (int)(data[y, x] * 255);
                imagePointer[x] = (byte)grayValue;
            }

            imagePointer += imageData.Stride;
        }
    }

    image.UnlockBits(imageData);

    return image;
}

void GenerateBinaryImageData(int value, ref float[,] imageData)
{
    int width = imageData.GetLength(1);
    int height = imageData.GetLength(0);

    int index = 0;
    for (int y = 0; y < height; y++)
    {
        for (int x = 0; x < width; x++)
        {
            int binaryValue = (value >> index) & 1; // Get the current bit
            float grayscaleValue = binaryValue * 1.0f; // Map 0 to 0.0 and 1 to 1.0
            imageData[y, x] = grayscaleValue;
            index++;
        }
    }
}