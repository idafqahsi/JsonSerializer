using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Configuration
    {
        public Configuration(int version, string domainName, string[] ipAddresses)
        {
            Version = version;
            DomainName = domainName;
            IpAddresses = ipAddresses;
        }

        public int Version;
        public string DomainName;
        public string[] IpAddresses;

    }

}
