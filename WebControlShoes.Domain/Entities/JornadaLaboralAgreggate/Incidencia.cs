using WebControlShoes.Domain;


namespace Zapatillas.Domain.Entities


{
    public class Incidencia : EntidadBase<Guid>, IAggregateRoot
    {

        public List<Defecto>  _defectos;

        public Incidencia( Pie pie)
        {
            Defectos = new List<Defecto>();
            Hora = DateTime.Now.Hour;
            Pie = pie;
        }
        public int Hora { get; set; }
        public Pie Pie { get; set; }
        public virtual List<Defecto> Defectos { get { return _defectos; } set { _defectos = value; } }
        public Defecto obtenerDefecto(Guid idDefecto)
        {
            return Defectos.Where(d => d.Id == idDefecto)
                           .Single();
        }

        public List<Defecto> GetDefectos()
        {
            return Defectos;
        }

        public void AddDefecto(Defecto defecto)
        {
            defecto.Cantidad++;
            _defectos.Add(defecto);
        }
    }
}