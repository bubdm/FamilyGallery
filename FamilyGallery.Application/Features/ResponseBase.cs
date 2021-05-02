namespace FamilyGallery.Application.Features
{
    public abstract class ResponseBase
    {
        public bool IsSuccessful { get; set; }

        public string Message { get; set; }
    }
}