using Karate_Data_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace krate_business_Layer
{
    public class clsSettings_Business
    {
        public static byte DefaultSubscriptionPeriod()
        {
            return clsSettingsDateAccessLayer.DefaultSubscriptionPeriod();
        }

        public static byte DefaultTestPeriod()
        {
            return clsSettingsDateAccessLayer.DefaultTestPeriod();
        }
    }
}

