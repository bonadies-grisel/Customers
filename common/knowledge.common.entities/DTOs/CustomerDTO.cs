namespace knowledge.common.entities.DTOs
{
    public class CustomerDTO
    {
        #region Public Properties        
        public int Id { get; set; }
        public string Names { get; set; }            
        public string Surnames { get; set; }        
        public DateOnly BirthDate { get; set; }        
        public string CUIT { get; set; }
        public string Address { get; set; }
        public string CellphoneNumber { get; set; }
        public string Email { get; set; } 
        #endregion
    }
}
