namespace food_tracker_api.Models
{
    public class StoragePlace
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public StorageType StorageType { get; set; }
        public int StorageCapacity { get; set; }
        public int CurrentCapacity { get; set; }
        public bool IsFull { get; set; }
        public string StorageLocation { get; set; }
    }
}