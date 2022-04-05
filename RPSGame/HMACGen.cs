using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace RPSGame
{
    public class HMACGen
    {
        public string pcMove;
        public Byte[] hmacKey;
        public Byte[] hmacSha2;
        public HMACGen(string pcMove)
        {
            this.pcMove = pcMove;
            hmacKey = createKey();
            hmacSha2 = createHMAC();            
        }
        public Byte[] createKey()
        {
            var rng = RandomNumberGenerator.Create();
            Byte[] HMACKey = new byte[256 / 8];
            rng.GetBytes(HMACKey);
            return HMACKey;
        }
        public Byte[] createHMAC()
        {
            Byte[] pcMoveInByte = Encoding.Default.GetBytes(pcMove);
            HMACSHA256 hmac = new HMACSHA256(hmacKey);
                return hmac.ComputeHash(Encoding.UTF8.GetBytes(pcMove));
        }
    }
}
