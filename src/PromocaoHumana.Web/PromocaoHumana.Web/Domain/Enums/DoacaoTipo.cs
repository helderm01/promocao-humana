using System;

namespace PromocaoHumana.Web.Domain.Enums
{
    [Flags]
    public enum DoacaoTipo : int
    {
        Alimento,
        Roupas,
    }
}