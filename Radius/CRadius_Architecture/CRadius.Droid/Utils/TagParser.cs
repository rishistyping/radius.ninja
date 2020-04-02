using System;
using Android.Nfc;
using Android.Content;

namespace CRadius.Droid
{
    public static class TagParser
    {
        #region Methods
        public static string GetNdefData(Intent intent)
        {
            string result = default(string);
            if (intent.Action == NfcAdapter.ActionNdefDiscovered)
            {
                NdefMessage msg = (NdefMessage)intent.GetParcelableArrayExtra(NfcAdapter.ExtraNdefMessages)[0];
                byte[] payload = msg.GetRecords()[0].GetPayload();

                result = System.Text.Encoding.UTF8.GetString(payload);

                var endIndex = result.IndexOf("en");
                if (endIndex >= 0)
                {
                    result = result.Remove(0, endIndex + 2);
                }
            }
            return result;
        }

        public static string GetTagId(Intent intent)
        {
            string result = default(string);
            try
            {
                var idBytes = intent.GetByteArrayExtra(NfcAdapter.ExtraId);
                result = BytesConverter.DecBytesToHexString(idBytes);
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            return result;
        }
        #endregion
    }
}