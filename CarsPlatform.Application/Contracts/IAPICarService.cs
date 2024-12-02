namespace CarsPlatform.Application.Contracts
{
    public interface IAPICarService
    {
        List<string> GetModels(string make);

        Dictionary<string, int> GetMakes();
    }
}
