﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using QRCoder;
using System.IO;

namespace authx
{
    public partial class auth : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void Image1_PreRender(object sender, EventArgs e)
        {
            var qrGenerator = new QRCodeGenerator();
            QRCode qrCode = new QRCode(qrGenerator.CreateQrCode("site=authx;?q=117546", QRCodeGenerator.ECCLevel.Q));
            Image1.Height = 200;
            Image1.Width = 200;
            System.Drawing.Bitmap bitmap = qrCode.GetGraphic(20);
            MemoryStream ms = new MemoryStream();
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            byte[] byteImage = ms.ToArray();
            Image1.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
        }

        
    }
}