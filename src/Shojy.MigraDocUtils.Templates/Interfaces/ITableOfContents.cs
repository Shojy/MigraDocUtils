namespace Shojy.MigraDocUtils.Templates
{
    public interface ITableOfContents : IDocumentPart
    {
        void ScanForHeadings(IDocumentTemplate document);
    }
}