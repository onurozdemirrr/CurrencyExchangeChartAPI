using Microsoft.EntityFrameworkCore.Storage;

namespace DataAPI
{
    public class KurRepository
    {
        TCMBContext tcmbContext = new TCMBContext();

        public void Kaydet(List<ResponseData> kurListesi)
        {
            foreach (ResponseData responseData in kurListesi)
            {
                List<ResponseDataKur> gunlukKurlar = responseData.Data;

                foreach (var kur in gunlukKurlar)
                {
                    tcmbContext.ResponseDataKurs.Add(kur);
                    tcmbContext.SaveChanges();
                }
            }
        }
        public List<ResponseDataKur> GetAllKurByName(string dovizKodu)
        {
            return tcmbContext.ResponseDataKurs.Where(x=> x.DovizKodu == dovizKodu).ToList();
        }
    }
}
