namespace RoomBooking.API.Models
{
    public class PeminjamanRuangan
    {
        public int Id { get; set; }
        // Id= = PK 
        public string NRP { get; set; }

        public string Ruangan { get; set; }

        public DateOnly Tanggal { get; set; }

        public string JamMulai { get; set; }

        public string JamSelesao { get; set; }

        public string Keperluan { get; set; }

        public string Status { get; set; } = "Menunggu";
    }
}