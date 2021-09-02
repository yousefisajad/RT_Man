namespace RepairToolsMan.Application.Contracts.Equipment
{
    public class EquipmentViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Picture { get; set; }
        public long unitPrice { get; set; }
        public string Category { get; set; }
        public string InsertDate { get; set; }
        public long CategoryId { get; set; }
    }
}
