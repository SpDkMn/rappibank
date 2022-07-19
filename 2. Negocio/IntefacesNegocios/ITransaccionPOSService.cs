using POSEntity;

namespace IntefacesNegocios
{
    public interface ITransaccionPOSService
    {
        Task<bool> Save(TransaccionPOSBE Transaccion);
    }
}
