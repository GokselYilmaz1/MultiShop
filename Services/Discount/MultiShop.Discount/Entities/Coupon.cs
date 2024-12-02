namespace MultiShop.Discount.Entities
{
    public class Coupon
    {
        // Uygulamamdaki indirim kuponlarını entities klasörü içerisinde tutulacak.
        public int CouponId { get; set; } // Kuponun ID'si
        public string Code { get; set; } // Kuponu Kodu
        public int Rate { get; set; } // Kuponun İndirim Oranı
        public bool IsActive { get; set; } // Kupon Aktif mi ? İstediğimiz zaman pasif hale getirilebilecek.
        public DateTime ValidDate { get; set; } // Kupon ne zamana kadar geçerli ?
    }
}
