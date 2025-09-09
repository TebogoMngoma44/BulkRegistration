namespace Speccon.Learnership.FrontEnd.Models.Qualification
{
    public class QualificationTypeDto
    {
        public int QualificationTypeId { get; set; }
        public Guid QualificationTypeKey { get; set; }
        public string QualificationTypeDescription { get; set; } = string.Empty;
        public int RecordStatusId { get; set; }
        public byte[] RowVersion { get; set; }
        public DateTime CreateDate { get; set; }
    }






}
