using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int responseCode = 0;
            string responseMessage = string.Empty;

            CreateShipments(out responseCode, out responseMessage);
        }

        public static string CreateShipments(out Int32 responseCode, out String responseMessage)
        {
            responseCode = 0;
            responseMessage = string.Empty;
            bool hasErrors = false;
            string comments = string.Empty;
            string pickupId = string.Empty;

            AramexShippingService.Service_1_0Client shipmentService = null;

            List<AramexShippingService.ProcessedShipment> processedShipment = new List<AramexShippingService.ProcessedShipment>();
            processedShipment = null;
            shipmentService = new AramexShippingService.Service_1_0Client();
            shipmentService.Open();
            AramexShippingService.ClientInfo clientInfo = new AramexShippingService.ClientInfo();
            clientInfo.AccountCountryCode = Utility.GetAppSettingsValue<string>("Shipment_ACCOUNT_COUNTRY_CODE");
            clientInfo.AccountEntity = Utility.GetAppSettingsValue<string>("Shipment_ACCOUNT_ENTITY");
            clientInfo.AccountNumber = Utility.GetAppSettingsValue<string>("Shipment_ACCOUNT_NUMBER");
            clientInfo.AccountPin = Utility.GetAppSettingsValue<string>("Shipment_ACCOUNT_PIN");
            clientInfo.Password = Utility.GetAppSettingsValue<string>("Shipment_PASSWORD");
            clientInfo.UserName = Utility.GetAppSettingsValue<string>("Shipment_USERNAME");
            clientInfo.Version = Utility.GetAppSettingsValue<string>("Shipment_VERSION");
            List<AramexShippingService.Notification> result = new List<AramexShippingService.Notification>();
            AramexShippingService.Transaction transaction = new AramexShippingService.Transaction();
            List<AramexShippingService.Shipment> shipmentList = new List<AramexShippingService.Shipment>();
            AramexShippingService.Shipment shipment = null;

            //Consignee
            shipment = new AramexShippingService.Shipment();
            shipment.Consignee = new AramexShippingService.Party();
            shipment.Consignee.Contact = new AramexShippingService.Contact();
            shipment.Consignee.PartyAddress = new AramexShippingService.Address();
            shipment.Consignee.PartyAddress.City = "Muscat";
            shipment.Consignee.PartyAddress.CountryCode = Utility.GetAppSettingsValue<string>("Consignee_Country");
            shipment.Consignee.PartyAddress.Line1 = "abc";
            shipment.Consignee.PartyAddress.PostCode = "113";
            shipment.Consignee.Contact.CellPhone = "95500000";
            shipment.Consignee.Contact.PhoneNumber1 = "95500000";
            shipment.Consignee.Contact.CompanyName = Utility.GetAppSettingsValue<string>("Consignor_CompanyName");
            shipment.Consignee.Contact.EmailAddress = "mirza.danish.baig@hotmail.com";
            shipment.Consignee.Contact.PersonName = "ooredoo Test";
            shipment.Consignee.AccountNumber = Utility.GetAppSettingsValue<string>("Shipment_ACCOUNT_NUMBER");

            //Consignor
            shipment.Shipper = new AramexShippingService.Party();
            shipment.Shipper.Contact = new AramexShippingService.Contact();
            shipment.Shipper.PartyAddress = new AramexShippingService.Address();
            shipment.Shipper.PartyAddress.City = Utility.GetAppSettingsValue<string>("Consignor_City");
            shipment.Shipper.PartyAddress.CountryCode = Utility.GetAppSettingsValue<string>("Consignor_Country");
            shipment.Shipper.PartyAddress.Line1 = Utility.GetAppSettingsValue<string>("Consignor_HouseNumber");
            shipment.Shipper.Contact.CellPhone = Utility.GetAppSettingsValue<string>("Consignor_TelephoneNumber");
            shipment.Shipper.Contact.PhoneNumber1 = Utility.GetAppSettingsValue<string>("Consignor_TelephoneNumber");
            shipment.Shipper.Contact.CompanyName = Utility.GetAppSettingsValue<string>("Consignor_CompanyName");
            shipment.Shipper.Contact.EmailAddress = Utility.GetAppSettingsValue<string>("Consignor_Email");
            shipment.Shipper.Contact.PersonName = Utility.GetAppSettingsValue<string>("Consignor_PersonName");
            shipment.Shipper.AccountNumber = Utility.GetAppSettingsValue<string>("Shipment_ACCOUNT_NUMBER");


            //third party
            shipment.ThirdParty = new AramexShippingService.Party();
            shipment.ThirdParty.Contact = new AramexShippingService.Contact();
            shipment.ThirdParty.PartyAddress = new AramexShippingService.Address();
            shipment.ThirdParty.PartyAddress.Line1 = Utility.GetAppSettingsValue<string>("ThirdParty_HouseNumber");
            shipment.ThirdParty.PartyAddress.City = Utility.GetAppSettingsValue<string>("ThirdParty_City");
            shipment.ThirdParty.PartyAddress.CountryCode = Utility.GetAppSettingsValue<string>("ThirdParty_CountryCode");
            shipment.ThirdParty.Contact.PersonName = Utility.GetAppSettingsValue<string>("ThirdParty_FirstName");
            shipment.ThirdParty.Contact.CompanyName = Utility.GetAppSettingsValue<string>("ThirdParty_CompanyName");
            shipment.ThirdParty.Contact.PhoneNumber1 = Utility.GetAppSettingsValue<string>("ThirdParty_TelephoneNumber");
            shipment.ThirdParty.Contact.CellPhone = Utility.GetAppSettingsValue<string>("ThirdParty_ContactNumber");
            shipment.ThirdParty.Contact.EmailAddress = Utility.GetAppSettingsValue<string>("ThirdParty_Email");


            //Details
            shipment.ShippingDateTime = DateTime.Now;
            shipment.AccountingInstrcutions = "";
            shipment.Attachments = null;
            shipment.Details = new AramexShippingService.ShipmentDetails();
            shipment.Details.ActualWeight = new AramexShippingService.Weight();
            shipment.Details.ActualWeight.Value = Utility.GetAppSettingsValue<double>("Shipment_Weight");
            shipment.Details.ActualWeight.Unit = "KG";
            shipment.Details.ChargeableWeight = new AramexShippingService.Weight();
            shipment.Details.ChargeableWeight.Value = Utility.GetAppSettingsValue<double>("Consignor_ChanrgeableWeightValue");
            shipment.Details.ChargeableWeight.Unit = "KG";
            shipment.Details.Dimensions = new AramexShippingService.Dimensions();
            shipment.Details.Dimensions.Length = 1.00;
            shipment.Details.Dimensions.Height = 1.00;
            shipment.Details.Dimensions.Width = 1.00;
            shipment.Details.Dimensions.Unit = "CM";
            shipment.Details.CashOnDeliveryAmount = new AramexShippingService.Money();
            shipment.Details.CashOnDeliveryAmount.Value = 0;
            shipment.Details.CashOnDeliveryAmount.CurrencyCode = "OMR";
            shipment.Details.CollectAmount = new AramexShippingService.Money();
            shipment.Details.DescriptionOfGoods = Utility.GetAppSettingsValue<string>("Consignor_DescriptionOfGoods");
            shipment.Details.GoodsOriginCountry = Utility.GetAppSettingsValue<string>("Consignor_GoodsOriginCountry");
            shipment.Details.Items = new List<AramexShippingService.ShipmentItem>();
            AramexShippingService.ShipmentItem shipmentItem = new AramexShippingService.ShipmentItem();
            shipmentItem.Weight = new AramexShippingService.Weight();
            shipmentItem.Weight.Unit = "KG";
            shipmentItem.Weight.Value = 1;
            shipmentItem.PiecesDimensions = new List<AramexShippingService.Dimensions>();
            AramexShippingService.Dimensions itemsDimensions = new AramexShippingService.Dimensions();
            itemsDimensions.Height = 1;
            itemsDimensions.Width = 1;
            itemsDimensions.Length = 1;
            itemsDimensions.Unit = "CM";
            shipmentItem.PiecesDimensions.Add(itemsDimensions);
            shipmentItem.GoodsDescription = Utility.GetAppSettingsValue<string>("Consignor_DescriptionOfGoods");
            shipmentItem.CountryOfOrigin = Utility.GetAppSettingsValue<string>("Consignor_GoodsOriginCountry");
            shipment.Details.Items.Add(shipmentItem);
            shipment.Details.NumberOfPieces = 1;
            shipment.Details.ProductGroup = "EXP";
            shipment.Details.ProductType = "1";
            shipment.Details.PaymentType = "P";

            /////// // shipment.Attachments = "";
            shipment.DueDate = DateTime.Now;

            shipmentList.Add(shipment);
            AramexShippingService.LabelInfo labelInfo = new AramexShippingService.LabelInfo();
            labelInfo.ReportID = Utility.GetAppSettingsValue<int>("Shipment_ReportID");
            labelInfo.ReportType = Utility.GetAppSettingsValue<string>("Shipment_ReportType");
            /* private Nawras.AdapterFramework.BusinessLogic.AramexShippingService.Party ShipperField;
            private Nawras.AdapterFramework.BusinessLogic.AramexShippingService.Party ConsigneeField;
            [System.Runtime.Serialization.OptionalFieldAttribute()]
            private Nawras.AdapterFramework.BusinessLogic.AramexShippingService.Party ThirdPartyField;*/

            result = shipmentService.CreateShipments(clientInfo, ref transaction, ref shipmentList, labelInfo, out hasErrors);
            shipmentService.Close();
            if (hasErrors == true || result != null && result.Count > 0)
            {
                if (result.Where(a => a.Code.Contains("ERR")).Count() > 0)
                {
                    responseCode = 1;
                    responseMessage = result.ToList().Where(a => a.Code.Contains("ERR")).Select(b => b.Message).FirstOrDefault();
                }
                else if (processedShipment.Count > 0)
                {
                    responseCode = 1;
                    responseMessage = processedShipment.FirstOrDefault().Notifications.FirstOrDefault().Message;
                }
                if (result[0].Code == "0" || result[1].Code == "0")
                {
                    if (processedShipment != null && processedShipment.Count > 0)
                    {
                        pickupId = processedShipment[0].ID;
                        pickupId = shipmentList.FirstOrDefault().PickupGUID;
                        return pickupId;
                    }
                }
            }
            return pickupId;



        }
    }

    public class Utility
    {

        /// <summary>
        /// Get App Settings Value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="appSettingsKey"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static T GetAppSettingsValue<T>(string appSettingsKey, bool requiredBaseUrl = false)
        {
            string appSettingsValue = ConfigurationManager.AppSettings.Get(appSettingsKey);

            if (!string.IsNullOrEmpty(appSettingsValue))
            {
                return (T)Convert.ChangeType(appSettingsValue, typeof(T));
            }

            return default(T);
        }


    }
}
