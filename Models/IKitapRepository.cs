namespace WebUygulamaProje1.Models
{
    public interface IKitapRepository: IRepository<Kitap>
    {
        void Güncelle (Kitap kitap);
        void Kaydet();
    }
}
