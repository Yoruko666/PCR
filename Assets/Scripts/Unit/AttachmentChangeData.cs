using Spine;

[System.Serializable]
public class AttachmentChangeData
{
	public string TargetAttachmentName;
	public string AppliedAttachmentName;

	public int TargetIndex { get; set; }
	public Attachment TargetAttachment { get; set; }
	public Attachment AppliedAttachment { get; set; }

	public AttachmentChangeData() { }
}
