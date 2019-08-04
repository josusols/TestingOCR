using System;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace testingOCR
{
    public partial class F_main : Form
    {
        PictureBox picB;
        HttpClient client;
        string keyAttr;
        string endpointAttr;
        string filePath;
        
        public F_main()
        {
            InitializeComponent();
            keyAttr = ConfigurationManager.AppSettings.Get("computer-vision-key");
            endpointAttr = ConfigurationManager.AppSettings.Get("endpoint");
        }

        /// <summary>
        /// Returns the contents of the specified file as a byte array.
        /// </summary>
        /// <param name="imageFilePath">The image file to read.</param>
        /// <returns>The byte array of the image data.</returns>
        static byte[] GetImageAsByteArray(string imageFilePath)
        {
            // Open a read-only file stream for the specified file.
            using (FileStream fileStream =
                new FileStream(imageFilePath, FileMode.Open, FileAccess.Read))
            {
                // Read the file's contents into a byte array.
                BinaryReader binaryReader = new BinaryReader(fileStream);
                return binaryReader.ReadBytes((int)fileStream.Length);
            }
        }

        private void LL_uploadImage_Click(object sender, EventArgs e)
        {
            OPF_image.Title = "Open image";
            OPF_image.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (OPF_image.ShowDialog() == DialogResult.OK)
            {
                picB = new PictureBox();
                picB.Image = new Bitmap(OPF_image.FileName);
                filePath = OPF_image.FileName;
                PB_image.Image = picB.Image;
            }
        }

        async private void BTN_analyze_Click(object sender, EventArgs e)
        {
            if (picB != null)
            {
                //Azure Computer Vision call.
                client = new HttpClient();
                var queryString = HttpUtility.ParseQueryString(string.Empty);

                // Request headers
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", keyAttr);
                
                // Request parameters
                queryString["language"] = "en";
                queryString["detectOrientation"] = "true";
                var uri = endpointAttr + "/vision/v2.0/ocr?" + queryString;
                
                // Request body
                HttpResponseMessage response;
                
                // Read the contents of the specified local image
                // into a byte array.
                byte[] byteData = GetImageAsByteArray(filePath);

                // Add the byte array as an octet stream to the request body.
                using (var content = new ByteArrayContent(byteData))
                {
                    // This example uses the "application/octet-stream" content type.
                    // The other content types you can use are "application/json"
                    // and "multipart/form-data".
                    content.Headers.ContentType =
                        new MediaTypeHeaderValue("application/octet-stream");

                    // Asynchronously call the REST API method.
                    response = await client.PostAsync(uri, content);
                }

                // Asynchronously get the JSON response.
                var textResponse = await response.Content.ReadAsStringAsync();
                var imgText = JsonConvert.DeserializeObject<imageText>(textResponse);
                StringBuilder finalText = new StringBuilder();
                foreach (var region in imgText.regions)
                {
                    foreach (var line in region.lines)
                    {
                        foreach (var word in line.words)
                        {
                            finalText.Append(word.text);
                            finalText.Append(" ");
                        }
                        finalText.AppendLine();
                    }
                    finalText.AppendLine();
                }
                RTB_response.Text = textResponse;
                MessageBox.Show(finalText.ToString(), ".::FINAL TEXT::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error, imagen expected", ".::ERROR::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
