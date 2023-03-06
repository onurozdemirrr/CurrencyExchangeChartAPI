using DataAPI;

namespace BusinessAPI.Concrete
{
    public class DovizManager
    {
        KurRepository _repository = new KurRepository();
        
        public List<ResponseDataKur> GetAllKurByName(string dovizKodu)
        {
            return _repository.GetAllKurByName(dovizKodu);
        }
    }
}
