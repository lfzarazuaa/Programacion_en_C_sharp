using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formularios_Mantenimiento
{
    public class ErrorProv
    {
        private ErrorProvider _ctrlErrorProvider;
        /// <summary>
        /// Bit de error, verdadero indica error.
        /// </summary>
        private bool bError;
        
        public ErrorProv(ErrorProvider ctrlErrorProvider)
        {
            _ctrlErrorProvider = ctrlErrorProvider;//Control de error.
            bError = false;//Inicializa el error en falso.
        }
        /// <summary>
        /// Activa el error en un control si la condicional es verdadera.
        /// </summary>
        /// <param name="conditional">Condicional que decide si activar el error.</param>
        /// <param name="control">Control sobre el cual se indicará el mensaje.</param>
        /// <param name="message">Mensaje de error.</param>
        public void HasError(bool conditional,Control control, string message)
        {
            if (conditional)
            {
                _ctrlErrorProvider.SetError(control, message);
                bError = true;//Definir el error en activo.
            }
        }
        /// <summary>
        /// Activa el error en un control.
        /// </summary>
        /// <param name="control">Control sobre el cual se indicará el mensaje.</param>
        /// <param name="message">Mensaje de error.</param>
        public void SetError(Control control, string message)
        {
            _ctrlErrorProvider.SetError(control, message);
            bError = true;//Definir el error en activo.
        }
        /// <summary>
        /// Inicializar el estado sin error.
        /// </summary>
        public void InitializeError()
        {
            _ctrlErrorProvider.Clear();
            bError = false;
        }
        /// <summary>
        /// Obtener si hubo error, se resetea al ejecutar.
        /// </summary>
        /// <returns></returns>
        public bool GetError()
        {
            if (bError)//Si habia error lo resetea a su estado original.
            {
                bError = false;
                return true;
            }
            return false;
        }
        /// <summary>
        /// Obtener si hubo error (elimina acción de Dialog Result), se resetea al ejecutar.
        /// </summary>
        /// <returns></returns>
        public bool GetError(Form btn)
        {
            if (bError)//Si habia error lo resetea a su estado original.
            {
                btn.DialogResult = DialogResult.None;
                bError = false;
                return true;
            }
            return false;
        }
    }
}
