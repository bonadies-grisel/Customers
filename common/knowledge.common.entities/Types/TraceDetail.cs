#region Usings
using System.ComponentModel.DataAnnotations; 
#endregion

namespace knowledge.common.entities.Types
{
    public class TraceDetail : EntityBase<int>
    {
        #region Public Properties
        [Required(ErrorMessage = "Required field.")]        
        [StringLength(100, ErrorMessage = "Value cannot be more than 100 characters.")]
        public string Clave { get; set; }

        [Required(ErrorMessage = "Required field.")]        
        [StringLength(65535, ErrorMessage = "Value cannot be more than 65535 characters.")]
        public string Valor { get; set; }
        #endregion

        #region Navigation Properties
        public Trace Trace { get; set; } 
        #endregion
    }
}
