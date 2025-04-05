public interface IDataProvider
{
    public void Save();
    public void Delete();
    public bool TryLoad();
}
