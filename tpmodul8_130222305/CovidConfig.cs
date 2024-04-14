using System;
using Internal;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json;

namespace tpmodul8_130222305
{
	public class CovidConfig
	{
        public string satuanSuhu { get; set; }
        public int batasHarianDemam { get; set; }
        public string pesanDitolak { get; set; }
        public string pesanDiterima { get; set; }

        public void UbahSatuan()
        {
            satuanSuhu = satuanSuhu == "celsius" ? "fahrenheit" : "celsius";
        }
    }
}


