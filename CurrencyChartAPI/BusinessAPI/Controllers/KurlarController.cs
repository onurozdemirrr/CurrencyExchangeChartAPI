using BusinessAPI.Concrete;
using BusinessAPI.model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusinessAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KurlarController : ControllerBase
    {
        DovizManager manager = new DovizManager();

        [HttpPost]
        [Route("GetCurrencyByCode/{currencyCode}")]
        public IActionResult GetCurrencyByCode(string currencyCode)
        {
            var sonuc = manager.GetAllKurByName(currencyCode);
            //tarih
            //döviz satış/alış 
            List<KurModel> KurModelList = new List<KurModel>();

            foreach (var item in sonuc)
            {
                KurModel kurModel = new KurModel();
                kurModel.Tarih= item.Tarih;
                kurModel.DovizSatis = item.DovizSatis;
                KurModelList.Add(kurModel);
            }

            return Ok(KurModelList);
        }
    }
}
