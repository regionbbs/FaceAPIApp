using Microsoft.Azure.CognitiveServices.Vision.Face;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FaceApp
{
    public partial class Form1 : Form
    {
        private IList<Guid> _faceIds1;
        private IList<Guid> _faceIds2;

        public Form1()
        {
            InitializeComponent();

            _faceIds1 = new List<Guid>();
            _faceIds2 = new List<Guid>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.png";

                if (ofd.ShowDialog() == DialogResult.Cancel)
                    return;

                var file = ofd.FileName;
                txtFileName1.Text = file;
                pictureBox1.Image = Image.FromStream(File.OpenRead(file)); 
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                SendFaceAPI(1, txtFaceInfo1, txtFileName1.Text);
            }
        }

        private async void SendFaceAPI(int idx, TextBox textbox, string imageSource)
        {
            var fa = new List<FaceAttributeType>() {
                FaceAttributeType.Glasses, 
                FaceAttributeType.Smile,
                FaceAttributeType.Gender, 
                FaceAttributeType.Emotion, //快樂指數
                FaceAttributeType.Age,
                FaceAttributeType.FacialHair, //面部毛髮,
                FaceAttributeType.HeadPose //頭部姿勢
            };

            var client = GetFaceClient();
            var list = await client.Face.DetectWithStreamAsync(File.OpenRead(imageSource), returnFaceAttributes: fa);

            if (list.Count == 0)
                textbox.Text = "No any face detected.";
            else
            {
                foreach (var item in list)
                {
                    textbox.Text += $"FaceID：{item.FaceId } \r\n";
                    textbox.Text += $"性別：{item.FaceAttributes.Gender}\r\n";
                    textbox.Text += $"年齡：{item.FaceAttributes.Age}\r\n";
                    textbox.Text += $"微笑：{item.FaceAttributes.Smile}\r\n";
                    textbox.Text += $"眼鏡：{item.FaceAttributes.Glasses}\r\n";
                    textbox.Text += $"鬍子：{item.FaceAttributes.FacialHair.Moustache}\r\n";
                    textbox.Text += $"快樂指數：{item.FaceAttributes.Emotion.Happiness}";

                    if (idx == 1)
                        _faceIds1.Add(item.FaceId.Value);
                    else if (idx == 2)
                        _faceIds2.Add(item.FaceId.Value);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.png";

                if (ofd.ShowDialog() == DialogResult.Cancel)
                    return;

                var file = ofd.FileName;
                txtFileName2.Text = file;
                pictureBox2.Image = Image.FromStream(File.OpenRead(file));
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

                SendFaceAPI(2, txtFaceInfo2, txtFileName2.Text);
            }
        }

        private async void cmdVerifyFaces_Click(object sender, EventArgs e)
        {
            int count = 0;
            var client = GetFaceClient();

            foreach (var faceId1 in _faceIds1)
            {
                foreach (var faceId2 in _faceIds2)
                {
                    var result = await client.Face.VerifyFaceToFaceAsync(faceId1, faceId2);
                    if (result.IsIdentical)
                        count++;
                }
            }

            MessageBox.Show("Face comparison identical count: " + count.ToString());
        }

        private FaceClient GetFaceClient()
        {
            var credential = new ApiKeyServiceClientCredentials("face_api_key");
            var client = new FaceClient(credential)
            {
                Endpoint = "https://[face-api-endpoint].cognitiveservices.azure.com"
            };

            return client;
        }

        //private async Task SendFaceAPI()
        //{
        //    var client = new HttpClient();
        //    var queryString = HttpUtility.ParseQueryString(string.Empty);

        //    // Request headers
        //    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "51c988f484ad4a11bdbc51a192e5df56");

        //    // Request parameters
        //    queryString["returnFaceId"] = "true";
        //    queryString["returnFaceLandmarks"] = "false";
        //    queryString["returnFaceAttributes"] = "{string}";
        //    queryString["recognitionModel"] = "recognition_01";
        //    queryString["returnRecognitionModel"] = "false";
        //    queryString["detectionModel"] = "detection_01";
        //    var uri = "https://faceapi-20200516.cognitiveservices.azure.com/face/v1.0/detect?" + queryString;

        //    HttpResponseMessage response;

        //    // Request body
        //    var stream = new MemoryStream();
        //    _selectedImage.Save(stream, ImageFormat.Jpeg);
        //    stream.Flush();
        //    stream.Position = 0;
        //    byte[] byteData = stream.ToArray();

        //    using (var content = new ByteArrayContent(byteData))
        //    {
        //        content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
        //        response = await client.PostAsync(uri, content);
        //    }

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var content = await response.Content.ReadAsStringAsync();
        //        var array = JArray.Parse(content);

        //        var o = array.First().ToObject<JObject>();
        //        txtFaceID.Text = o.Property("faceId").Value.ToString();
        //    }
        //}
    }
}
