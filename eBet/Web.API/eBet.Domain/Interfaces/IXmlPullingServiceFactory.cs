using eBet.Domain.Services;

namespace eBet.Domain.Interfaces
{
    public interface IXmlPullingServiceFactory
    {
        XmlPullingService Create();
    }
}