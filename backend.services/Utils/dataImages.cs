namespace backend.services.Utils
{
    public class ImagesData
    {
        private byte[] GetImageBytes(string path)
        {
            if (!System.IO.File.Exists(path))
            {
                return new byte[0];
            }

            return System.IO.File.ReadAllBytes(path);
        }

        public string GetImage(string path)
        {
            var imageBytes = GetImageBytes(path);
            return "data:image/png; base64," + Convert.ToBase64String(imageBytes);
        }

        public string GetImageWithoutBase(string path)
        {
            var imageBytes = GetImageBytes(path);
            return Convert.ToBase64String(imageBytes);
        }

    }
}
