namespace WebUygulamaProje1.Models
{
    public interface IKitapTuruRepository: IRepository<KitapTuru>
    {
        void Güncelle (KitapTuru kitapTuru);
        void Kaydet();
    }
}
