using System.ComponentModel.DataAnnotations;

namespace DataAPI
{
    public class RequestData
    {
        public int Gun { get; set; }
        public int Ay { get; set; }
        public int Yil { get; set; }
        public bool IsBugun { get; set; }

    }
    public class ResponseData
    {
        public List<ResponseDataKur>? Data { get; set; }
    }

    public class ResponseDataKur
    {
        [Key]
        public int Id { get; set; }
        public string? Tarih { get; set; }
        public string? DovizKodu { get; set; }
        public int Birim { get; set; }
        public string? DovizCinsi { get; set; }
        public decimal DovizAlis { get; set; }
        public decimal DovizSatis { get; set; }
        public decimal EfektifAlis { get; set; }
        public decimal EfektifSatis { get; set; }
    }
}
