using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpAddressValidatorKata
{
    [TestFixture]
    public class IpAddressValidatorTests
    {
        [TestCase("1.1.1.1")]
        [TestCase("192.168.1.1")]
        [TestCase("127.0.0.1")]
        public void ValidateIpv4Address_GivenValidIpaddressWithFourBlocksSeparatedByDot_ShouldReturnTrue(string ipAddress)
        {
            //--------------------Arrange--------------------------------
            var ipAddressValidator = CreateIpAddressValidator();

            //--------------------Act------------------------------------
            var actual = ipAddressValidator.ValidateIpv4Address(ipAddress);

            //--------------------Assert---------------------------------
            var expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1")]
        [TestCase("192.168.5")]
        [TestCase("10.0.0.1.4")]
        public void ValidateIpv4Address_GivenIpaddressWithInvalidNumberOfBlocksSeparatedByDot_ShouldReturnTrue(string ipAddress)
        {
            //--------------------Arrange--------------------------------
            var ipAddressValidator = CreateIpAddressValidator();

            //--------------------Act------------------------------------
            var actual = ipAddressValidator.ValidateIpv4Address(ipAddress);

            //--------------------Assert---------------------------------
            var expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1.1.1.0")]
        [TestCase("192.168.1.0")]
        [TestCase("10.0.0.0")]
        public void ValidateIpv4Address_GivenIpaddressWithFourBlocksSeparatedByDotAndEndsWithZero_ShouldReturnFalse(string ipAddress)
        {
            //--------------------Arrange--------------------------------
            var ipAddressValidator = CreateIpAddressValidator();

            //--------------------Act------------------------------------
            var actual = ipAddressValidator.ValidateIpv4Address(ipAddress);

            //--------------------Assert---------------------------------
            var expected = false;
            Assert.AreEqual(expected, actual);
        }
        
        [TestCase("1.0.1.255")]
        [TestCase("192.168.0.255")]
        [TestCase("255.255.255.255")]
        public void ValidateIpv4Address_GivenIpaddressWithFourBlocksSeparatedByDotAndEndsWith255_ShouldReturnFalse(string ipAddress)
        {
            //--------------------Arrange--------------------------------
            var ipAddressValidator = CreateIpAddressValidator();

            //--------------------Act------------------------------------
            var actual = ipAddressValidator.ValidateIpv4Address(ipAddress);

            //--------------------Assert---------------------------------
            var expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestCase("198.ten.1.1")]
        [TestCase("198.ten.1.one")]
        [TestCase("ten.one.one.1")]
        public void ValidateIpv4Address_GivenIpaddressWithFourBlocksOneContainingString_ShouldReturnFalse(string ipAddress)
        {
            //--------------------Arrange--------------------------------
            var ipAddressValidator = CreateIpAddressValidator();

            //--------------------Act------------------------------------
            var actual = ipAddressValidator.ValidateIpv4Address(ipAddress);

            //--------------------Assert---------------------------------
            var expected = false;
            Assert.AreEqual(expected, actual);
        }

        private static IpAddressValidator CreateIpAddressValidator()
        {
            return new IpAddressValidator();
        }
    }
}
