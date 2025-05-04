using System;

public interface IDataManager
{
    public Action OnInitializationComplete { get; set; }
    public void Initialize();
}
