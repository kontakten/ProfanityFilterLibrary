using System.Threading.Tasks;

namespace ProfanityFilterLibrary
{
    public interface IProfanityReaderService
    {
        ITextReplaceLogic TextReplacer { get; }

        Task ValidateProfanity();
    }
}