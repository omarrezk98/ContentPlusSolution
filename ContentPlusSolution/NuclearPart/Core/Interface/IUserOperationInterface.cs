namespace Core.Interface
{
	public interface IUserOperationInterface
	{
        public string CreatedId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? ModifiedId { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}

