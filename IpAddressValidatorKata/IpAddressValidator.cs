using System;
using System.Linq;

namespace IpAddressValidatorKata
{
    public class IpAddressValidator
    {
        public bool ValidateIpv4Address(string ipAddress)
        {
            var blocks = ipAddress.Split('.').Length;
            if (blocks == 4)
            {
                var status = ValidateIpAddress(ipAddress);

                return status;
            }
            return false;
        }

        private bool ValidateIpAddress(string ipAddress)
        {
            var containsString = ipAddress.Split('.').Any(ip => int.TryParse(ip, out int invalid).Equals(false));
            if (containsString)
            {
                return false;
            }
            var lastBlock = ipAddress.Split('.').Last();
            var incorrectLastBlock = new[] { "0", "255" };

            return !incorrectLastBlock.Contains(lastBlock);
        }

    }
}