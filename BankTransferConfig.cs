using System;
using System.Text.Json;
using System.Text
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankTransfer
{
    public class BankTransferConfig
    {
        private Config config;
        private string filePath;

        class Transfer
        {
            public int lang { get; set; }
            public int nama { get; set; }
            public Transfer transfer { get; set; }
            public list<String> Method { get; set; }
            public Confirmation confirmation { get; set; }

        }

        public class Transfer
        {
            public String threshold { get; set; }
            public String low_fee { get; set; }
            public String high_fee { get; set; }
        }

        public class Confirmation
        {
            public String en { get; set; }
            public String id { get; set; }
        }


        class UIConfig
        {
            public BankTransferConfig config;
            public const String filePath = @"bank_transfer_config.json";
            public UIConfig()
            {
                try
                {
                    ReadConfigFile();
                }
                catch (Exception)
                {
                    SetDefault();
                    WriteNewConfigFile();
                }
            }
        }

        public BankTransferConfig ReadConfig()
        {
            String configJsonData = File.ReadAllText(filePath);
            config = JsonSerializer.Deserialize<Config>(configJsonData);
            return config;
        }

        private Config ReadConfigFile()
        {
            String configJsonData = File.ReadAllText(filePath);
            config = JsonSerializer.Deserialize<Config>(configJsonData);
            return config;
        }

        private void SetDefault()
        {
            config = new BankTransferConfig();
            config lang = "en";
            config.transfer.threshold = "25000000";
            config.transfer.low_fee = "6500";
            config.transfer.high_fee = "15000";
            config.transfer.Method = new List<String> {"[ “RTO (real-time)”, “SKN”, “RTGS”, “BI FAST” ]"};
            config.confirmation.en = "yes";
            config.confirmation.id = "ya";
        }

        private void WriteNewConfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            String jsonString = JsonSerializer.Serialize(value: BankTransferConfig, options);
            File.WriteAllText(filePath, jsonString);
        }
    }
}
