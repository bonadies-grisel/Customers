#region Usings
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#endregion

namespace knowledge.common.entities.Types
{
    public class Trace : EntityBase<int>
    {
        #region Constructors
        /// <summary>
        ///     Instanciates a new log object.
        /// </summary>
        public Trace()
        {
            Detalles = new List<TraceDetail>();
        }
        #endregion

        #region Public Properties
        [Required(ErrorMessage = "Required field.")]
        [Range(typeof(DateTime), "1/1/0001", "12/31/9999", ErrorMessage = "Invalid date range.")]        
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Required field.")]        
        [StringLength(100, ErrorMessage = "Value cannot be more than 100 characters.")]
        public string Aplicacion { get; set; }

        [Required(ErrorMessage = "Required field.")]        
        [StringLength(100, ErrorMessage = "Value cannot be more than 100 characters.")]
        public string Modulo { get; set; }

        [Required(ErrorMessage = "Required field.")]        
        [StringLength(200, ErrorMessage = "Value cannot be more than 200 characters.")]
        public string Componente { get; set; }

        [Required(ErrorMessage = "Required field.")]
        public bool Exception { get; set; }

        [Required(ErrorMessage = "Required field.")]        
        [StringLength(65535, ErrorMessage = "Value cannot be more than 65535 characters.")]
        public string Mensaje { get; set; }

        [NotMapped]
        public bool Active { get; set; }
        #endregion

        #region Navigation Properties
        public ICollection<TraceDetail> Detalles { get; set; }
        #endregion

        #region Public Methods
        public void AddContext(TraceDetail context)
        {
            Detalles.Add(context);
        }
        #endregion
    }
}
