namespace Violinews.Models
{
    public record Post(
        Guid Id,
        string Title,
        string Content,
        DateTime CreationDate);

    
}
