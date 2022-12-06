namespace Lab6.Data
{
    public interface IGeneralOperationsService
    {
        Task LoadObjects();
        Task DeleteObject(int id);
    }
}
