using System.Threading.Tasks;

namespace ProfanityFilterLibrary
{
    public interface ITextReaderService
    {
        ITextReplaceLogic TextReplacer { get; }
        void LoadText();
        void ValidateProfanity();
    }
}