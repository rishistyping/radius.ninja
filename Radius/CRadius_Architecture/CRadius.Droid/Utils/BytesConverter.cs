using System;

namespace CRadius.Droid
{
    public static class BytesConverter
    {
        #region Methods
        public static string DecBytesToHexString(byte[] bytesArray)
        {
            string result = default(String);
            try
            {
                foreach (byte byteData in bytesArray)
                {
                    string dec = byteData.ToString();
                    int number = int.Parse(dec);
                    string hexStr = number.ToString("x");
                    result += hexStr + ":";
                }
                result = result.Remove(result.Length - 1);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
            return result?.ToUpper();
        }
        #endregion
    }
}