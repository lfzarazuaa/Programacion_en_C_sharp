using System.Windows.Forms;

namespace Formularios_Mantenimiento.Mantenimiento_Productos
{
    public interface IFormPopup
    {
        AccionPopup Accion { get; set; }
        string Id { get; set; }
        void IncializarPopup(AccionPopup accion,string id);
        void AgregarRecurso();
        void EditarRecurso();
        void LeerValoresDeControles();
        
    }
}