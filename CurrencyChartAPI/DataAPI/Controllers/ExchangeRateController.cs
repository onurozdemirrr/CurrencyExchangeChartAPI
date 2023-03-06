using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml;

namespace DataAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeRateController : ControllerBase
    {
        [HttpPost]
        public List<ResponseData> Run(int day = 60)
        {
            List<ResponseData> responseDatas = new List<ResponseData>();
            DateTime Ilkgun = DateTime.Now.AddDays(-day);
            //https://www.tcmb.gov.tr/kurlar/202301/27012023.xml

            RequestData requestData = new RequestData();
            for (int i = 0; i < day; i++)
            {
                DateTime tarih = Ilkgun.AddDays(i);
                if (tarih.DayOfWeek.ToString() != "Saturday" && tarih.DayOfWeek.ToString() != "Sunday")
                {


                    requestData.Gun = tarih.Day;
                    requestData.Ay = tarih.Month;
                    requestData.Yil = tarih.Year;
                    requestData.IsBugun = false;

                    ResponseData resultForDay = new ResponseData();
                    string tcmbUrl = string.Format
                        ("https://www.tcmb.gov.tr/kurlar/{0}.xml",
                        (requestData.IsBugun) ? "today" : string.Format("{2}{1}/{0}{1}{2}",
                        requestData.Gun.ToString().PadLeft(2, '0'),
                        requestData.Ay.ToString().PadLeft(2, '0'),
                        requestData.Yil.ToString()
                        ));
                    resultForDay.Data = new List<ResponseDataKur>();
                    XmlDocument doc = new XmlDocument();
                    if (tcmbUrl != null)
                    {
                        doc.Load(tcmbUrl);  // XML'i ilgili linkten aldık.

                        // XML içindeki veriler okunacak.
                        foreach (XmlNode node in doc.SelectNodes("Tarih_Date")[0].ChildNodes)
                        {
                            ResponseDataKur kur = new ResponseDataKur();
                            kur.Tarih = doc.SelectNodes("Tarih_Date")[0].Attributes["Tarih"].Value;
                            kur.DovizKodu = node.Attributes["Kod"].Value;
                            kur.Birim = int.Parse(node["Unit"].InnerText);
                            kur.DovizCinsi = node["Isim"].InnerText;
                            kur.DovizAlis = Convert.ToDecimal("0" + node["ForexBuying"].InnerText.Replace(",", ","));
                            kur.DovizSatis = Convert.ToDecimal("0" + node["ForexSelling"].InnerText.Replace(",", ","));
                            kur.EfektifAlis = Convert.ToDecimal("0" + node["BanknoteBuying"].InnerText.Replace(",", ","));
                            kur.EfektifSatis = Convert.ToDecimal("0" + node["BanknoteSelling"].InnerText.Replace(",", ","));

                            resultForDay.Data.Add(kur);
                        }
                    responseDatas.Add(resultForDay);
                    }
                    else
                    {
                        Console.Write("hata var");
                    }

                }
            }
            // Veri tabanı kaydetme işlemleri yapılacak.

            KurRepository repository = new KurRepository();
            repository.Kaydet(responseDatas);

            return responseDatas;
        }
    }
}
