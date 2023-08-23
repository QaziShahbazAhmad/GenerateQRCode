using Microsoft.AspNetCore.Mvc;
using QRCoder;

namespace GenerateQRCode.Controllers
{
    public class QRController : Controller
    {
        public IActionResult Index()
        {
            // Url which we want to embed in QR Code
            var url = "https://www.linkedin.com/in/shahbaz-ahmad-8a934b5a";

            QRCodeData qrCodeData;
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {
                qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
            }

            // Image Format
            var imgType = Base64QRCode.ImageType.Png;

            var qrCode = new Base64QRCode(qrCodeData);
            //Base64 Format
            string qrCodeImageAsBase64 = qrCode.GetGraphic(20, SixLabors.ImageSharp.Color.BlanchedAlmond, SixLabors.ImageSharp.Color.White, true, imgType);

            //Sending Image format and base64 format to View
            TempData["qrCodeImageAsBase64"] = qrCodeImageAsBase64;
            TempData["imgType"] = imgType.ToString().ToLower();

            return View();
        }
    }
}
