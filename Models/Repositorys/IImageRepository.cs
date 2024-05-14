namespace BTH_BUOI1.Models.Repositorys
{
    public interface IImageRepository
    {
        Image Upload (Image image);
        List<Image> GetAllInfoImages ();

        (byte[], string, string) DownloadFile(int id);
    }
}
