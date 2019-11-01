using System;
namespace DominicanWhoCodes.Connectivity.Apis
{
    public interface IApiService
    {
        IDWCApi DWCApi { get; set; }
    }
}
