using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListviewProje.Classes;

namespace ListviewProje.Models.Entity
{
    public class PaymentDocument : DbObject
    {
        [Custom(FieldName = "Hesap No")] public string AccountCode { get; set; }

        [Custom(FieldName = "Belge Tarihi")]
        public DateTime DocumentDate { get; set; }
        [Custom(FieldName = "Belge Numarası")]
        public string DocumentNo { get; set; }
        [Custom(FieldName = "Firma Adı")]
        public Company Firm { get; set; }
        [Custom(FieldName = "Açıklama")]
        public string Description { get; set; }


        [Custom(FieldName = "Kesinlik")]
        public bool IsDefinitive { get; set; }
        [Custom(FieldName = "Değiştirilemez")]
        public bool Unchangeable { get; set; }

        [Custom(FieldName = "Vade Tarihi")]
        public DateTime MaturityDate { get; set; }
        [Custom(FieldName = "Vade Gün Sayısı")]
        public int MaturityDay { get; set; }

        [Custom(FieldName = "Borç")]
        public double Debt { get; set; }
        [Custom(FieldName = "Alacak")]
        public double Credit { get; set; }
        [Custom(FieldName = "Bakiye")]
        public double Balance { get; set; }
        [Custom(FieldName = "Yeni Vade Tarihi")]
        public DateTime NewMaturityDate { get; set; }
        [Custom(FieldName = "Ödenen")]
        public double Paid { get; set; }
        [Custom(FieldName = "Belgeyi Ekleyen")]
        public User Creator { get; set; }
        [Custom(FieldName = "Son Düzenleyen")]
        public User LastUser { get; set; }
    }
}
