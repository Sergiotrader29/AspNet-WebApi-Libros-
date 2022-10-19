namespace webapi.DTOs
{
    public class PaginacionDTO
    {
        public int Pagina { get; set; } = 1;
        private int recordsPorPagina = 10;  //ESTO ES UN CAMPO
        private readonly int cantidadMaximaPorPagina = 50; //LOGICA CANTIDAD MAXIMA PAGINA

        public int RecordsPorPagina
        {
            get
            {
                return recordsPorPagina;
            }
            set
            {
                recordsPorPagina = (value > cantidadMaximaPorPagina) ? cantidadMaximaPorPagina : value; // OPERADOR TERNARIO, FORMULA. 
                 //Ejemplo si el cliente me manda 100  es mayor que 50 entonces pongame la maxima  que es 50. si es menor me pone la menor.

            }
        }
    }
}
