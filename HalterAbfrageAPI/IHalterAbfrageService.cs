using HalterAbfrageAPI.Models;

namespace HalterAbfrageAPI
{
    public interface IHalterAbfrageService
    {
        Task<Fahrzeug> GetFahrzeugByKennzeichen(string kennzeichen);
    }
}
