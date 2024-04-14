// See https://aka.ms/new-console-template for more information
using System;
using Internal;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json;
using tpmodul8_130222305;

class Program
{
    static void Main(string[] args)
    {
        string jsonFilePath = "/Users/darasheibamalikachoiriyyah/Desktop/✧.* /KPL/tpmodul8_130222305/tpmodul8_130222305/CovidConfig.json";
        CovidConfig config;

        using (FileStream fs = File.OpenRead(jsonFilePath))
        {
            config = JsonSerializer.Deserialize<CovidConfig>(fs);
        }

        Console.WriteLine($"Berapa suhu badan anda saat ini? Dalam nilai {config.SatuanSuhu}");
        double suhu = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam?");
        int hariDemam = Convert.ToInt32(Console.ReadLine());

        bool suhuValid = false;
        bool hariDemamValid = false;

        if (config.SatuanSuhu == "celsius")
            suhuValid = suhu >= 36.5 && suhu <= 37.5;
        else if (config.satuanSuhu == "fahrenheit")
            suhuValid = suhu >= 97.7 && suhu <= 99.5;

        hariDemamValid = hariDemam < config.batasHarianDemam;

        if (suhuValid && hariDemamValid)
            Console.WriteLine(config.PesanDiterima);
        else
            Console.WriteLine(config.PesanDitolak);

        config.UbahSatuan();

        using (FileStream fs = File.OpenWrite(jsonFilePath))
        {
            JsonSerializer.SerializeAsync<CovidConfig>(fs, config);
        }
    }
}

