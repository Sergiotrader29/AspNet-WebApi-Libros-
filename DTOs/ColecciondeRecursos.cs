namespace webapi.DTOs
{
    public class ColecciondeRecursos
    {
        public class ColeccionDeRecursos<T> : Recurso where T : Recurso //hereda de recurso
        {
            public List<T> Valores { get; set; }
        }
    }
}
