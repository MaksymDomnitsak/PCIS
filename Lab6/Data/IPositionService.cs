namespace Lab6.Data
{
    public interface IPositionService : IGeneralOperationsService
    {
        List<Position> Positions { get; set; }
        Task<Position> GetSinglePosition(int id);
        Task CreatePosition(Position position);
        Task UpdatePosition(Position position, int id);
    }
}
