using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;




namespace EditImage
{
    public partial class ImageViwer : Form
    {
        int cnt;
        int max;
        int picnow;
        private IMAGE[] img = new IMAGE[6];
        int MouseDownPointX;
        int MouseDownPointY;
        int MouseUpPointX;
        int MouseUpPointY;
        bool isSelected;
        bool hasimage = false;
        bool toRotate = false;
        int delX;
        int delY;
        int angle = 0;
        Point mouseDown;
        Point mouseUp;

        public ImageViwer()
        {
            InitializeComponent();
            cnt = 0;
    
            btSaveImg.Enabled = false;
            btLastImg.Enabled = false;
            btNextImg.Enabled = false;
        
        }


        private void btOpenImage_Click(object sender, EventArgs e)
        {
            hasimage = true;
            OpenFileDialog openFileDia = new OpenFileDialog();
            if (openFileDia.ShowDialog() == DialogResult.OK)
            {
                cnt = 0;
                max = 0;
                picnow = 0;
                string path_Directory = openFileDia.FileName.Substring(0, openFileDia.FileName.LastIndexOf("\\"));
                string[] files = System.IO.Directory.GetFiles(path_Directory);
                foreach (string filename in files)
                {
                    try
                    {
                        string name = filename.Substring(filename.LastIndexOf("\\"), filename.Length - filename.LastIndexOf("\\"));
                        string filetype = filename.Substring(filename.LastIndexOf("."), filename.Length - filename.LastIndexOf("."));
                        if (filetype == ".jpg")
                        {
                            img[cnt] = new IMAGE(Image.FromFile(path_Directory + name), 0, 0, 0, 0);
                            cnt++;
                            if (filename == openFileDia.FileName)
                                picnow = cnt - 1;
                        }
                    }
                    catch { }
                }
                max = cnt;
                cnt = picnow;
                btSaveImg.Enabled = true;
                btLastImg.Enabled = true;
                btNextImg.Enabled = true;
                this.ResizeAndDisplayImage(img[picnow]);
                
            }
        }

        private void ResizeAndDisplayImage(IMAGE OriginalImage)
        {          
            this.pbImage.BackColor = Color.White;

            if (OriginalImage == null)
                return;

            int sourceWidth = OriginalImage.imgSource.Width;
            int sourceHeight = OriginalImage.imgSource.Height;
            double ratio;

            //Calculate targetWidth and targetHeight, so that the image will fit into the pictureBox
            if ((sourceWidth != pbImage.Width) || (sourceHeight != pbImage.Height))
            {
                if (sourceHeight > OriginalImage.targetHeight)
                {
                    if (sourceHeight > pbImage.Height || sourceWidth > pbImage.Width)
                    {
                        OriginalImage.targetHeight = pbImage.Height;
                        ratio = (double)OriginalImage.targetHeight / sourceHeight;
                        OriginalImage.targetWidth = (int)(sourceWidth * ratio);
                        if (pbImage.Width < OriginalImage.targetWidth)
                        {
                            OriginalImage.targetWidth = pbImage.Width;
                            ratio = (double)OriginalImage.targetWidth / sourceWidth;
                            OriginalImage.targetHeight = (int)(sourceHeight * ratio);
                        }
                        else if (pbImage.Height < OriginalImage.targetHeight)
                        {
                            OriginalImage.targetHeight = pbImage.Height;
                            ratio = (double)OriginalImage.targetHeight / sourceHeight;
                            OriginalImage.targetWidth = (int)(sourceWidth * ratio);
                        }
                    }
                    else 
                    {
                        OriginalImage.targetHeight = sourceHeight;
                        OriginalImage.targetWidth = sourceWidth;
                    }
                }


                OriginalImage.targetTop = (pbImage.Height - OriginalImage.targetHeight) / 2;
                OriginalImage.targetLeft = (pbImage.Width - OriginalImage.targetWidth) / 2;

                OriginalImage.targetTop = OriginalImage.targetTop > 0 ? OriginalImage.targetTop : 0;
                OriginalImage.targetLeft = OriginalImage.targetLeft > 0 ? OriginalImage.targetLeft : 0;
            }

            else
            {
                // Calculate the targetTop and targetLeft values, to center the image
                OriginalImage.targetTop = (pbImage.Height - sourceHeight) / 2;
                OriginalImage.targetLeft = (pbImage.Width - sourceWidth) / 2;
            }

            ShowImage(OriginalImage);

            this.updateImgInfo(OriginalImage.imgSource);
        }

        private void btNextImg_Click(object sender, EventArgs e)
        {
            cnt++;
            if (cnt >= max)
                cnt = 0;
            picnow = cnt;
            ResizeAndDisplayImage(img[picnow]);
        }

        private void btLastImg_Click(object sender, EventArgs e)
        {
            cnt--;
            if (cnt < 0)
                cnt = max - 1;
            picnow = cnt;
            ResizeAndDisplayImage(img[picnow]);
        }

        private void btRotateImg_Click(object sender, EventArgs e)
        {
            toRotate = true;
            angle += 180;
            if (angle == 360)
                angle = 0;
            ShowImage(img[picnow]);
            toRotate = false;
        }
      
        private void updateImgInfo(Image image)
        {
            this.lbHeightImg.Text = image.Height.ToString();
            this.lbWidthImg.Text = image.Width.ToString();
        }

        private void EditImage_Resize(object sender, EventArgs e)
        {
            ResizeAndDisplayImage(img[picnow]);
        }

        #region ZOOM

        private void pbImage_MouseEnter_1(object sender, EventArgs e)
        {
            pbImage.Focus();
        }

        private void pbImage_MouseWheel(object sender, MouseEventArgs e)
        {
            IMAGE imgToZoom = img[picnow];

            double ratio;
            if (e.Delta > 0)
                ratio = e.Delta / 60;
            else
            {
                double k = e.Delta;
                k = -k;
                ratio = 80 / k;
            }
            imgToZoom.targetHeight = (int)(imgToZoom.targetHeight * ratio);
            imgToZoom.targetWidth = (int)(imgToZoom.targetWidth * ratio);

            imgToZoom.targetTop = (pbImage.Height - imgToZoom.targetHeight) / 2;
            imgToZoom.targetLeft = (pbImage.Width - imgToZoom.targetWidth) / 2;

            img[picnow] = imgToZoom;

            ShowImage(imgToZoom);
            
        }
        #endregion

        #region Pan
        private void pbImage_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MouseDownPointX = Cursor.Position.X;
                MouseDownPointY = Cursor.Position.Y;
                isSelected = true;
            }
        }

        private void pbImage_MouseUp(object sender, MouseEventArgs e)
        {
                if (e.Button == MouseButtons.Left)
                {
                    isSelected = false;     
                }
        }

        private void pbImage_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left && isSelected == true && hasimage == true)
            {

                MouseUpPointX = Cursor.Position.X;
                MouseUpPointY = Cursor.Position.Y;

                delX = MouseUpPointX - MouseDownPointX;
                delY = MouseUpPointY - MouseDownPointY;

                int PX = img[picnow].targetLeft + delX;
                int PY = img[picnow].targetTop + delY;

                if ((img[picnow].targetHeight > pbImage.Height) && (img[picnow].targetWidth < pbImage.Width))
                {
                    if (PY > 0)
                    {
                        img[picnow].targetTop = 0;
                    }
                    else if (PY < (pbImage.Height - img[picnow].targetHeight))
                    {
                        img[picnow].targetTop = pbImage.Height - img[picnow].targetHeight;
                    }
                    else
                    {
                        img[picnow].targetTop = PY;
                    }

                }
                else if ((img[picnow].targetWidth > pbImage.Width) && (img[picnow].targetHeight < pbImage.Height))
                {
                    if (PX > 0)
                    {
                        img[picnow].targetLeft = 0;
                    }
                    else if (PX < (pbImage.Width - img[picnow].targetWidth))
                    {
                        img[picnow].targetLeft = pbImage.Width - img[picnow].targetWidth;
                    }
                    else
                    {
                        img[picnow].targetLeft = PX;
                    }

                }
                else if ((img[picnow].targetWidth > pbImage.Width) && (img[picnow].targetHeight > pbImage.Height))
                {
                    if (PY > 0)
                    {
                        img[picnow].targetTop = 0;
                    }
                    else if (PY < (pbImage.Height - img[picnow].targetHeight))
                    {
                        img[picnow].targetTop = pbImage.Height - img[picnow].targetHeight;
                    }
                    else
                    {
                        img[picnow].targetTop = PY;
                    }



                    if (PX > 0)
                    {
                        img[picnow].targetLeft = 0;
                    }
                    else if (PX < (pbImage.Width - img[picnow].targetWidth))
                    {
                        img[picnow].targetLeft = pbImage.Width - img[picnow].targetWidth;
                    }
                    else
                    {
                        img[picnow].targetLeft = PX;
                    }
                }
                else { }

                //img[picnow].targetLeft = img[picnow].targetLeft + delX;
                //img[picnow].targetTop = img[picnow].targetTop + delY;

                //img[picnow].targetLeft = (img[picnow].targetLeft < 0) ? img[picnow].targetLeft : 0;
                //img[picnow].targetTop = (img[picnow].targetTop < 0) ? img[picnow].targetTop : 0;

                ShowImage(img[picnow]);

            }
        }

        #endregion

        private void ShowImage(IMAGE image)
        {
            // Create a new temporary bitmap to resize the original image
            // The size of this bitmap is the size of the picImage picturebox.

            Bitmap tempBitmap = new Bitmap(pbImage.Width, pbImage.Height, PixelFormat.Format24bppRgb);
            // Set the resolution of the bitmap to match the original resolution.
            tempBitmap.SetResolution(image.imgSource.HorizontalResolution, image.imgSource.VerticalResolution);
            // Create a Graphics object to further edit the temporary bitmap
            Graphics bmapGraphics = Graphics.FromImage(tempBitmap);
            bmapGraphics.Clear(Color.White);
            // Set the interpolationmode插值模式 since we are resizing an image here
            bmapGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            // Draw the original image on the temporary bitmap, resizing it using
            // the calculated values of targetWidth and targetHeight.
            bmapGraphics.DrawImage(image.imgSource
                , new Rectangle(image.targetLeft, image.targetTop, image.targetWidth, image.targetHeight)
                , new Rectangle(0, 0, image.imgSource.Width, image.imgSource.Height)
                , GraphicsUnit.Pixel);

            bmapGraphics.Dispose();

            if (toRotate == true)
               tempBitmap = RotateImage(tempBitmap, angle);

            pbImage.Image = tempBitmap;
        }

        private Bitmap RotateImage(Bitmap bmp, int angle)
        {
            int Width = bmp.Width;
            int Height = bmp.Height;
            Bitmap TempBmp = new Bitmap(Height, Width);
            switch (angle)
            { 
           
                case 90 :
                    using (Graphics bmpGraphic = Graphics.FromImage(TempBmp))
                    {
                        Point[] Points90 = {
                                            new Point (Height,0),
                                            new Point (Height,Width),
                                            new Point (0,0)
                                            };
                        bmpGraphic.DrawImage(bmp, Points90);
                        bmpGraphic.Dispose();
                    }
                        break;

                case 180:
                        using (Graphics bmpGraphic = Graphics.FromImage(TempBmp))
                        {
                            Point[] Points180 = {
                                            new Point(Width, Height), 
                                            new Point(0, Height),
                                            new Point(Width, 0)
                                            };
                            bmpGraphic.DrawImage(bmp, Points180);
                            bmpGraphic.Dispose();
                        }
                         break;

                case 270:
                         using (Graphics bmpGraphic = Graphics.FromImage(TempBmp))
                         {
                             Point[] Points270 = {
                                            new Point(0, Width), 
                                            new Point(0, 0),
                                            new Point(Height,Width)
                                            };
                             bmpGraphic.DrawImage(bmp, Points270);
                             bmpGraphic.Dispose();
                         }
                         break;
            }
                   
             
            return TempBmp;
        }

        #region SaveImage
        private void btSaveImg_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Filter = "jpeg pictures|*.jpg";
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                this.saveJpeg(savefile.FileName, new Bitmap(img[cnt].imgSource), 85L);
            }
        }

        private void saveJpeg(string path, Bitmap img, long quality)
        {
            EncoderParameter qualityPara = new EncoderParameter(Encoder.Quality, quality);
            ImageCodecInfo codeInfo = getEncoderInfo("image/jpeg");

            if (codeInfo == null)
            {
                return;
            }

            EncoderParameters encoderpara = new EncoderParameters(1);
            encoderpara.Param[0] = qualityPara;

            img.Save(path, codeInfo, encoderpara);

        
        }

        private ImageCodecInfo getEncoderInfo(string mimeType)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            for (int i = 0; i < codecs.Length; i++)
            {
                if (codecs[i].MimeType == mimeType)
                    return codecs[i];
            }
            return null;
            
           
        }

    
         #endregion 

       
    }

        #region CLASS IMAGE
    public class IMAGE
    {
        public Image imgSource;
        public int targetHeight;
        public int targetWidth;
        public int targetTop;
        public int targetLeft;

        public IMAGE(Image image, int height, int width, int top, int left) 
        {
            this.imgSource = image;
            this.targetHeight = height;
            this.targetWidth = width;
            this.targetTop = top;
            this.targetLeft = left;
        }

    }
    #endregion
}
      