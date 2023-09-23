// Clases para constraints

namespace webapi.Models;

[AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
public class CustomDataTypeAttribute : Attribute
{
    public string CustomDataType { get; }

    public CustomDataTypeAttribute(string customDataType)
    {
        CustomDataType = customDataType;
    }
}

public enum EstadoSolicitud
{
    Pendiente,
    Aceptada,
    Denegada
}
